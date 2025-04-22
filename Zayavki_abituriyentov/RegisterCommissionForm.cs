using Npgsql;
using System;
using System.Windows.Forms;

namespace Zayavki_abituriyentov
{
    public partial class RegisterCommissionForm : Form
    {
        public RegisterCommissionForm()
        {
            InitializeComponent();
        }

        private void RegisterCommissionForm_Load(object sender, EventArgs e)
        {
            // Логика загрузки формы (если нужно)
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Получаем значения из формы
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            // Проверка обязательных полей
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Валидация данных
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Введите корректный email.");
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Введите корректный номер телефона (10-15 цифр).");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну букву, одну цифру и быть не менее 6 символов.");
                return;
            }

            if (!IsLoginUnique(login))
            {
                MessageBox.Show("Логин уже существует. Пожалуйста, выберите другой.");
                return;
            }

            // Хешируем пароль с помощью BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Логика для добавления представителя комиссии в базу данных
            try
            {
                using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app"))
                {
                    connection.Open();

                    // Добавление пользователя в таблицу users
                    string userSql = "INSERT INTO users (Login, Password, Role_Id) VALUES (@Login, @Password, @Role) RETURNING id";
                    int userId = 0; // для получения ID нового пользователя
                    using (var command = new NpgsqlCommand(userSql, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        command.Parameters.AddWithValue("@Role", 2); // Роль 2 для представителя комиссии

                        // Получаем ID нового пользователя
                        userId = (int)command.ExecuteScalar();
                    }

                    // Добавление данных представителя комиссии в таблицу commission_representatives
                    string representativeSql = "INSERT INTO commission_representatives (full_name, email, phone, user_id) VALUES (@FullName, @Email, @Phone, @UserId)";
                    using (var command = new NpgsqlCommand(representativeSql, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@UserId", userId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Регистрация успешна!");
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{10,15}$");
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 6 &&
                   password.Any(char.IsDigit) &&
                   password.Any(char.IsLetter);
        }

        private bool IsLoginUnique(string login)
        {
            using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app"))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE Login = @Login";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count == 0;
                }
            }
        }

    }
}
