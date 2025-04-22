using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using Npgsql;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;



namespace Zayavki_abituriyentov
{
    public partial class AbiturientForm : Form
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app";

        public AbiturientForm()
        {
            InitializeComponent();
        }

        private void AbiturientForm_Load(object sender, EventArgs e)
        {
            // Не нужно загружать имя при старте формы, так как оно вводится пользователем.
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text; // Имя абитуриента из текстбокса
            var application = GetApplicationByFullName(fullName);
            if (application != null)
            {
                application.Status = "ПОДАНО";
                UpdateApplicationStatus(application);
                lblStatus.Text = $"Статус заявки: {application.Status}";
                MessageBox.Show("Статус обновлен!");
            }
            else
            {
                MessageBox.Show("Заявка не найдена!");
            }
        }

        private void btnPrintApplication_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text; // Имя абитуриента из текстбокса
            var application = GetApplicationByFullName(fullName);
            if (application != null)
            {
                CreateApplicationPdf(application);
                MessageBox.Show("Заявление распечатано!");
            }
            else
            {
                MessageBox.Show("Заявка не найдена!");
            }
        }

        // Поиск заявки по полному имени
        private AdmissionApplication GetApplicationByFullName(string fullName)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT a.* 
                    FROM Applications a
                    JOIN Abiturients ab ON a.Abiturient_Id = ab.Id
                    WHERE ab.Full_Name = @FullName
                    LIMIT 1";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AdmissionApplication
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                SubmissionDate = reader.GetDateTime(reader.GetOrdinal("Submission_Date")),
                                Comment = reader.IsDBNull(reader.GetOrdinal("Comment")) ? "" : reader.GetString(reader.GetOrdinal("Comment")),
                                AbiturientFullName = fullName
                            };
                        }
                    }
                }
            }

            return null;
        }

        private void UpdateApplicationStatus(AdmissionApplication application)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Applications SET Status = @Status WHERE Id = @Id";

                using (var command = new NpgsqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", application.Status);
                    command.Parameters.AddWithValue("@Id", application.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateApplicationPdf(AdmissionApplication application)
        {
            if (application == null || application.Status == null)
            {
                MessageBox.Show("Не удалось сформировать PDF — не загружены все данные.");
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Сохранить заявление как...";
                dlg.Filter = "PDF файлы (*.pdf)|*.pdf";
                dlg.FileName = $"Заявление_{application.AbiturientFullName}.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Создаем документ (правильный способ)
                        PdfDocument document = new PdfDocument();

                        // Добавляем страницу (правильный метод)
                        PdfPage page = document.Pages.Add();

                        XGraphics gfx = XGraphics.FromPdfPage(page);

                        // Шрифты
                        XFont fontTitle = new XFont("Arial", 18);
                        XFont fontNormal = new XFont("Arial", 12);

                        // Заголовок
                        gfx.DrawString("ЗАЯВЛЕНИЕ НА ПОСТУПЛЕНИЕ", fontTitle, XBrushes.Black,
                            new XRect(0, 40, page.Width, page.Height), XStringFormats.TopCenter);

                        // Основной текст
                        gfx.DrawString($"ФИО: {application.AbiturientFullName}", fontNormal, XBrushes.Black, 40, 100);
                        gfx.DrawString($"Дата подачи: {application.SubmissionDate:dd.MM.yyyy}", fontNormal, XBrushes.Black, 40, 130);
                        gfx.DrawString($"Статус: {application.Status}", fontNormal, XBrushes.Black, 40, 160);

                        // Сохраняем документ
                        document.Save(dlg.FileName);


                        // Открываем PDF
                        Process.Start(new ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }



        public class AdmissionApplication
        {
            public int Id { get; set; }
            public string AbiturientFullName { get; set; }
            public string Status { get; set; }
            public DateTime SubmissionDate { get; set; }
            public string Comment { get; set; }
        }
    }
}
