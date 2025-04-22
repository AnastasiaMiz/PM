using BCrypt.Net;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Zayavki_abituriyentov
{
    public partial class RegisterForm : Form
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app"; 

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Загружаем данные уровней образования
            comboBoxLevel.Items.Add("СПО");
            comboBoxLevel.Items.Add("Бакалавриат");
            comboBoxLevel.Items.Add("Специалитет");
            comboBoxLevel.Items.Add("Магистратура");

            // Выбираем первый элемент по умолчанию, если нужно
            // comboBoxLevel.SelectedIndex = 0; 
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранный уровень образования
            string selectedLevel = comboBoxLevel.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedLevel))
            {
                LoadDirections(selectedLevel); // Загружаем направления для выбранного уровня
            }
        }

        private void LoadDirections(string level)
        {
            // Очищаем текущий список направлений
            checkedListBoxDirections.Items.Clear();

            // Преобразуем уровень образования в числовое значение
            int levelId = GetLevelId(level);  // Эта функция вернет числовое значение уровня образования

            // Получаем направления из БД для выбранного уровня
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Name FROM Directions WHERE Level_id = @Level"; // Запрос с фильтром по уровню
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Level", levelId);  // Передаем числовое значение уровня образования
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string directionName = reader.GetString(reader.GetOrdinal("Name"));
                            checkedListBoxDirections.Items.Add(directionName, false); // Добавляем направление в checkedListBox
                        }
                    }
                }
            }
        }

        // Функция для получения числового значения уровня образования
        private int GetLevelId(string level)
        {
            switch (level)
            {
                case "СПО":
                    return 1;
                case "Бакалавриат":
                    return 2;
                case "Специалитет":
                    return 3;
                case "Магистратура":
                    return 4;
                default:
                    throw new ArgumentException("Неизвестный уровень образования");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Получаем данные из формы
            string fullName = txtFullName.Text;
            string passportData = txtPassportData.Text;
            string snils = txtSnils.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string parentName = txtParentName.Text;
            string school = txtSchool.Text;
            string level = comboBoxLevel.SelectedItem?.ToString(); // Делаем проверку на null
            var selectedDirections = checkedListBoxDirections.CheckedItems.Cast<string>().ToList();
            string averageScoreText = txtAverageScore.Text;
            string documentUrl = txtDocumentUrl.Text;
            string login = txtLogin.Text; // Получаем логин
            string password = txtPassword.Text; // Получаем пароль

            // Проверка на обязательные поля
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || selectedDirections.Count == 0 || string.IsNullOrEmpty(averageScoreText) || string.IsNullOrEmpty(documentUrl) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Все поля обязательны для заполнения!");
                return;
            }

            // Проверка уровня образования
            if (string.IsNullOrEmpty(level))
            {
                MessageBox.Show("Выберите уровень образования!");
                return;
            }

            // Проверка среднего балла
            double averageScore;
            if (!double.TryParse(averageScoreText, out averageScore))
            {
                MessageBox.Show("Введите корректный средний балл!");
                return;
            }

            // Хэшируем пароль
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password); // Хэшируем пароль перед сохранением

            // Создаем нового абитуриента
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Вставляем нового абитуриента в базу данных
                    string insertAbiturientSql = "INSERT INTO Abiturients (Full_Name, Passport, Snils, Email, Phone, Parent_Name, Previous_School, Average_Score, Document_Url, Status) VALUES (@FullName, @PassportData, @Snils, @Email, @Phone, @ParentName, @PreviousSchool, @AverageScore, @DocumentUrl, @Status) RETURNING Id";
                    using (var command = new NpgsqlCommand(insertAbiturientSql, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@PassportData", passportData);
                        command.Parameters.AddWithValue("@Snils", snils);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@ParentName", parentName);
                        command.Parameters.AddWithValue("@PreviousSchool", school);
                        command.Parameters.AddWithValue("@AverageScore", averageScore);
                        command.Parameters.AddWithValue("@DocumentUrl", documentUrl);
                        command.Parameters.AddWithValue("@Status", "Pending"); // Статус по умолчанию

                        // Получаем ID абитуриента после вставки
                        int abiturientId = (int)command.ExecuteScalar();

                        // Теперь добавляем логин и хэшированный пароль в таблицу Users
                        string insertUserSql = "INSERT INTO Users (Login, Password, Role_id) VALUES (@Login, @Password, @RoleId)";
                        using (var userCommand = new NpgsqlCommand(insertUserSql, connection))
                        {
                            // Присваиваем роль "Абитуриент" (предположим, что Role_id = 1)
                            userCommand.Parameters.AddWithValue("@Login", login);
                            userCommand.Parameters.AddWithValue("@Password", hashedPassword); // Используем хэшированный пароль
                            userCommand.Parameters.AddWithValue("@RoleId", 1); // Role_id для абитуриента
                            userCommand.ExecuteNonQuery();
                        }

                        // Теперь добавляем выбранные направления
                        foreach (var directionName in selectedDirections)
                        {
                            // Получаем ID направления
                            string selectDirectionSql = "SELECT Id FROM Directions WHERE Name = @Name";
                            using (var directionCommand = new NpgsqlCommand(selectDirectionSql, connection))
                            {
                                directionCommand.Parameters.AddWithValue("@Name", directionName);
                                int directionId = (int)directionCommand.ExecuteScalar();

                                // Вставляем запись о связи абитуриента и направления
                                string insertDirectionSql = "INSERT INTO AbiturientDirections (AbiturientId, DirectionId) VALUES (@AbiturientId, @DirectionId)";
                                using (var insertDirectionCommand = new NpgsqlCommand(insertDirectionSql, connection))
                                {
                                    insertDirectionCommand.Parameters.AddWithValue("@AbiturientId", abiturientId);
                                    insertDirectionCommand.Parameters.AddWithValue("@DirectionId", directionId);
                                    insertDirectionCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Регистрация прошла успешно!");

                // Возвращаем на форму авторизации
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации абитуриента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Валидации
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Введите корректный email.");
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Введите корректный номер телефона (10–15 цифр).");
                return;
            }

            if (!IsValidPassport(passportData))
            {
                MessageBox.Show("Паспорт должен содержать ровно 10 цифр.");
                return;
            }

            if (!IsValidSnils(snils))
            {
                MessageBox.Show("Введите СНИЛС в формате XXX-XXX-XXX XX.");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Пароль должен быть не менее 6 символов и содержать буквы и цифры.");
                return;
            }

            if (!IsLoginUnique(login))
            {
                MessageBox.Show("Такой логин уже существует. Выберите другой.");
                return;
            }

        }


        private void txtPhone_TextChanged(object sender, EventArgs e)
             {
            // Логика для обработки изменений в поле телефона (если необходимо)
             }
        private void txtPassportData_TextChanged(object sender, EventArgs e)
        {
            // Логика для обработки изменений в поле паспортных данных (если необходимо)
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

        private bool IsValidPassport(string passport)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(passport, @"^\d{10}$");
        }

        private bool IsValidSnils(string snils)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(snils, @"^\d{3}-\d{3}-\d{3} \d{2}$");
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 6 &&
                   password.Any(char.IsDigit) &&
                   password.Any(char.IsLetter);
        }

        private bool IsLoginUnique(string login)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM Users WHERE Login = @Login";
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
