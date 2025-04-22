using System;
using System.Windows.Forms;
using BCrypt.Net;
using Npgsql;

namespace Zayavki_abituriyentov
{
    public partial class LoginForm : Form
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT u.Id, u.Login, u.Password, u.Role_id " +
                                 "FROM users u " +
                                 "WHERE u.Login = @Login";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader.GetString(reader.GetOrdinal("Password"));
                                int roleId = reader.GetInt32(reader.GetOrdinal("Role_id"));

                                // Прямое сравнение паролей без хеширования
                                if (password == storedPassword)
                                {
                                    if (roleId == 1)  // Абитуриент
                                    {
                                        MessageBox.Show("Добро пожаловать, абитуриент!");
                                        var abiturientForm = new AbiturientForm();
                                        abiturientForm.Show();
                                        this.Hide();
                                    }
                                    else if (roleId == 2)  // Приемная комиссия
                                    {
                                        MessageBox.Show("Добро пожаловать, работник приемной комиссии!");
                                        var commissionForm = new CommissionForm();
                                        commissionForm.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Неизвестная роль пользователя.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Неверный логин или пароль.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                }
            }
        }

        private bool IsPasswordOld(string hashedPassword)
        {
            // Проверяем, является ли версия соли устаревшей
            // Например, можно проверить длину соли
            return hashedPassword.Length != 60; // Эта проверка подходит для большинства случаев
        }

        private void UpdatePasswordInDatabase(NpgsqlConnection connection, string login, string newHashedPassword)
        {
            string updateQuery = "UPDATE users SET Password = @Password WHERE Login = @Login";

            using (var command = new NpgsqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Password", newHashedPassword);
                command.Parameters.AddWithValue("@Login", login);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Пароль был обновлен на новый хэш.");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void btnRegisterCommission_Click(object sender, EventArgs e)
        {
            var registerCommissionForm = new RegisterCommissionForm();
            registerCommissionForm.Show();
            this.Hide();
        }
    }
}