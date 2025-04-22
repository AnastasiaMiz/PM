using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;


namespace Zayavki_abituriyentov
{
    public partial class CommissionForm : Form
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app";

        public CommissionForm()
        {
            InitializeComponent();
            btnExportToCSV.Click += btnExportToCSV_Click;
        }

        private void CommissionForm_Load(object sender, EventArgs e)
        {

            LoadApplications();   // Загружаем заявки
            LoadStatuses();       // Загружаем статусы в ComboBox
        }

        private void LoadStatuses()
        {
            comboBoxStatus.Items.Clear(); // Очистим на всякий случай

            // Добавляем фиксированные статусы
            comboBoxStatus.Items.Add("ПОДАНО");
            comboBoxStatus.Items.Add("ПРИНЯТО");
            comboBoxStatus.Items.Add("ОТКЛОНЕНО");

            // Устанавливаем значение по умолчанию (необязательно)
            if (comboBoxStatus.Items.Count > 0)
                comboBoxStatus.SelectedIndex = 0;
        }


        private void LoadApplications()
        {
            dataGridViewApplications.DataSource = null;
            dataGridViewApplications.Rows.Clear();
            dataGridViewApplications.Columns.Clear();

            dataGridViewApplications.Columns.Add("ApplicationId", "ID Заявки");
            dataGridViewApplications.Columns.Add("Full_Name", "ФИО Абитуриента");
            dataGridViewApplications.Columns.Add("Status", "Статус");
            dataGridViewApplications.Columns.Add("Submission_Date", "Дата подачи");
            dataGridViewApplications.Columns.Add("Comment", "Комментарий");

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"
             SELECT 
                a.Id AS ApplicationId,
                ab.Full_Name,
                a.Status,
                a.Submission_Date,
                a.Comment
             FROM Applications a
             JOIN Abiturients ab ON a.Abiturient_Id = ab.Id";

                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int applicationId = reader.GetInt32(reader.GetOrdinal("ApplicationId"));
                        string fullName = reader.GetString(reader.GetOrdinal("Full_Name"));
                        string status = reader.GetString(reader.GetOrdinal("Status"));
                        DateTime submissionDate = reader.GetDateTime(reader.GetOrdinal("Submission_Date"));
                        string comment = reader.IsDBNull(reader.GetOrdinal("Comment")) ? string.Empty : reader.GetString(reader.GetOrdinal("Comment"));

                        dataGridViewApplications.Rows.Add(applicationId, fullName, status, submissionDate.ToString("dd.MM.yyyy"), comment);
                    }
                }
            }
        }


        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewApplications.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewApplications.SelectedRows[0];
                var applicationId = Convert.ToInt32(selectedRow.Cells["ApplicationId"].Value);
                string newStatus = comboBoxStatus.SelectedItem?.ToString();
                string comment = txtComment.Text;

                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Выберите новый статус заявки.");
                    return;
                }

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE Applications SET Status = @Status, Comment = @Comment WHERE Id = @Id";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Status", newStatus);
                        command.Parameters.AddWithValue("@Comment", comment);
                        command.Parameters.AddWithValue("@Id", applicationId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Статус заявки обновлен!");
                            LoadApplications(); // Перезагружаем таблицу
                        }
                        else
                        {
                            MessageBox.Show("Ошибка обновления статуса.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку.");
            }
        }

        private void buttonLvlDir_Click(object sender, EventArgs e)
        {
            var LevelsDirections = new LevelsDirections();
            LevelsDirections.Show();
            this.Hide();
        }


        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv";
            saveFileDialog.Title = "Сохранить таблицу как CSV";
            saveFileDialog.FileName = "Заявки_абитуриентов_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Записываем заголовки столбцов
                        for (int i = 0; i < dataGridViewApplications.Columns.Count; i++)
                        {
                            sw.Write(dataGridViewApplications.Columns[i].HeaderText);
                            if (i < dataGridViewApplications.Columns.Count - 1)
                                sw.Write(";");
                        }
                        sw.WriteLine();

                        // Записываем данные
                        foreach (DataGridViewRow row in dataGridViewApplications.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridViewApplications.Columns.Count; i++)
                                {
                                    if (row.Cells[i].Value != null)
                                    {
                                        string value = row.Cells[i].Value.ToString();
                                        // Экранируем кавычки и добавляем их если есть точка с запятой
                                        if (value.Contains(";") || value.Contains("\""))
                                        {
                                            value = value.Replace("\"", "\"\"");
                                            value = $"\"{value}\"";
                                        }
                                        sw.Write(value);
                                    }
                                    if (i < dataGridViewApplications.Columns.Count - 1)
                                        sw.Write(";");
                                }
                                sw.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Данные успешно экспортированы в CSV файл!", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте в CSV: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
