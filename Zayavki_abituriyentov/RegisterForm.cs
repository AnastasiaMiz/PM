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
            // ��������� ������ ������� �����������
            comboBoxLevel.Items.Add("���");
            comboBoxLevel.Items.Add("�����������");
            comboBoxLevel.Items.Add("�����������");
            comboBoxLevel.Items.Add("������������");

            // �������� ������ ������� �� ���������, ���� �����
            // comboBoxLevel.SelectedIndex = 0; 
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �������� ��������� ������� �����������
            string selectedLevel = comboBoxLevel.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedLevel))
            {
                LoadDirections(selectedLevel); // ��������� ����������� ��� ���������� ������
            }
        }

        private void LoadDirections(string level)
        {
            // ������� ������� ������ �����������
            checkedListBoxDirections.Items.Clear();

            // ����������� ������� ����������� � �������� ��������
            int levelId = GetLevelId(level);  // ��� ������� ������ �������� �������� ������ �����������

            // �������� ����������� �� �� ��� ���������� ������
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Name FROM Directions WHERE Level_id = @Level"; // ������ � �������� �� ������
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Level", levelId);  // �������� �������� �������� ������ �����������
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string directionName = reader.GetString(reader.GetOrdinal("Name"));
                            checkedListBoxDirections.Items.Add(directionName, false); // ��������� ����������� � checkedListBox
                        }
                    }
                }
            }
        }

        // ������� ��� ��������� ��������� �������� ������ �����������
        private int GetLevelId(string level)
        {
            switch (level)
            {
                case "���":
                    return 1;
                case "�����������":
                    return 2;
                case "�����������":
                    return 3;
                case "������������":
                    return 4;
                default:
                    throw new ArgumentException("����������� ������� �����������");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // �������� ������ �� �����
            string fullName = txtFullName.Text;
            string passportData = txtPassportData.Text;
            string snils = txtSnils.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string parentName = txtParentName.Text;
            string school = txtSchool.Text;
            string level = comboBoxLevel.SelectedItem?.ToString(); // ������ �������� �� null
            var selectedDirections = checkedListBoxDirections.CheckedItems.Cast<string>().ToList();
            string averageScoreText = txtAverageScore.Text;
            string documentUrl = txtDocumentUrl.Text;
            string login = txtLogin.Text; // �������� �����
            string password = txtPassword.Text; // �������� ������

            // �������� �� ������������ ����
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || selectedDirections.Count == 0 || string.IsNullOrEmpty(averageScoreText) || string.IsNullOrEmpty(documentUrl) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("��� ���� ����������� ��� ����������!");
                return;
            }

            // �������� ������ �����������
            if (string.IsNullOrEmpty(level))
            {
                MessageBox.Show("�������� ������� �����������!");
                return;
            }

            // �������� �������� �����
            double averageScore;
            if (!double.TryParse(averageScoreText, out averageScore))
            {
                MessageBox.Show("������� ���������� ������� ����!");
                return;
            }

            // �������� ������
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password); // �������� ������ ����� �����������

            // ������� ������ �����������
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // ��������� ������ ����������� � ���� ������
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
                        command.Parameters.AddWithValue("@Status", "Pending"); // ������ �� ���������

                        // �������� ID ����������� ����� �������
                        int abiturientId = (int)command.ExecuteScalar();

                        // ������ ��������� ����� � ������������ ������ � ������� Users
                        string insertUserSql = "INSERT INTO Users (Login, Password, Role_id) VALUES (@Login, @Password, @RoleId)";
                        using (var userCommand = new NpgsqlCommand(insertUserSql, connection))
                        {
                            // ����������� ���� "����������" (�����������, ��� Role_id = 1)
                            userCommand.Parameters.AddWithValue("@Login", login);
                            userCommand.Parameters.AddWithValue("@Password", hashedPassword); // ���������� ������������ ������
                            userCommand.Parameters.AddWithValue("@RoleId", 1); // Role_id ��� �����������
                            userCommand.ExecuteNonQuery();
                        }

                        // ������ ��������� ��������� �����������
                        foreach (var directionName in selectedDirections)
                        {
                            // �������� ID �����������
                            string selectDirectionSql = "SELECT Id FROM Directions WHERE Name = @Name";
                            using (var directionCommand = new NpgsqlCommand(selectDirectionSql, connection))
                            {
                                directionCommand.Parameters.AddWithValue("@Name", directionName);
                                int directionId = (int)directionCommand.ExecuteScalar();

                                // ��������� ������ � ����� ����������� � �����������
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

                MessageBox.Show("����������� ������ �������!");

                // ���������� �� ����� �����������
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ����������� �����������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // ���������
            if (!IsValidEmail(email))
            {
                MessageBox.Show("������� ���������� email.");
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("������� ���������� ����� �������� (10�15 ����).");
                return;
            }

            if (!IsValidPassport(passportData))
            {
                MessageBox.Show("������� ������ ��������� ����� 10 ����.");
                return;
            }

            if (!IsValidSnils(snils))
            {
                MessageBox.Show("������� ����� � ������� XXX-XXX-XXX XX.");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("������ ������ ���� �� ����� 6 �������� � ��������� ����� � �����.");
                return;
            }

            if (!IsLoginUnique(login))
            {
                MessageBox.Show("����� ����� ��� ����������. �������� ������.");
                return;
            }

        }


        private void txtPhone_TextChanged(object sender, EventArgs e)
             {
            // ������ ��� ��������� ��������� � ���� �������� (���� ����������)
             }
        private void txtPassportData_TextChanged(object sender, EventArgs e)
        {
            // ������ ��� ��������� ��������� � ���� ���������� ������ (���� ����������)
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
