using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zayavki_abituriyentov
{
    public partial class LevelsDirections : Form
    {
        public LevelsDirections()
        {
            InitializeComponent();
        }

        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=nastya2005;Database=University_app";


        private void LevelsDirections_Load(object sender, EventArgs e)
        {
            // Загружаем уровни и направления при загрузке формы
            LoadLevels();
        }


        private void LoadLevels()
        {
            comboBoxLevels.Items.Clear();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Name FROM education_levels";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Добавляем объект EducationLevel
                            comboBoxLevels.Items.Add(new EducationLevel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            // Устанавливаем свойства отображения
            comboBoxLevels.DisplayMember = "Name";  // Будет отображать только название уровня
            comboBoxLevels.ValueMember = "Id";      // Хранит идентификатор уровня

            if (comboBoxLevels.Items.Count > 0)
            {
                comboBoxLevels.SelectedIndex = 0;  // Выбираем первый уровень по умолчанию
            }
        }

        private void comboBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLevels.SelectedItem != null)
            {
                // Получаем выбранный уровень как EducationLevel
                var selectedLevel = (EducationLevel)comboBoxLevels.SelectedItem;
                LoadDirections(selectedLevel.Id);
            }
        }

        // Вспомогательный класс для хранения данных об уровне образования
        public class EducationLevel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void LoadDirections(int levelId)
        {
            dataGridViewDirections.Rows.Clear();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Name FROM directions WHERE Level_Id = @LevelId";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@LevelId", levelId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewDirections.Rows.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
        }

        private void btnAddLevel_Click(object sender, EventArgs e)
        {
            string levelName = txtLevelName.Text;
            if (string.IsNullOrEmpty(levelName))
            {
                MessageBox.Show("Пожалуйста, введите название уровня.");
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string insertSql = "INSERT INTO education_levels (Name) VALUES (@Name)";
                    using (var command = new NpgsqlCommand(insertSql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", levelName);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Уровень успешно добавлен.");
                LoadLevels();  // Обновляем список уровней
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении уровня: " + ex.Message);
            }
        }

        private void btnAddDirection_Click(object sender, EventArgs e)
        {
            string directionName = txtDirectionName.Text;
            if (string.IsNullOrEmpty(directionName))
            {
                MessageBox.Show("Пожалуйста, введите название направления.");
                return;
            }

            var selectedLevel = comboBoxLevels.SelectedItem as dynamic;
            if (selectedLevel == null)
            {
                MessageBox.Show("Пожалуйста, выберите уровень.");
                return;
            }

            int levelId = selectedLevel.Value;

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string insertSql = "INSERT INTO directions (Name, Level_Id) VALUES (@Name, @LevelId)";
                    using (var command = new NpgsqlCommand(insertSql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", directionName);
                        command.Parameters.AddWithValue("@LevelId", levelId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Направление успешно добавлено.");
                LoadDirections(levelId);  // Обновляем список направлений
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении направления: " + ex.Message);
            }
        }

        private void btnDeleteLevel_Click(object sender, EventArgs e)
        {
            var selectedLevel = comboBoxLevels.SelectedItem as dynamic;
            if (selectedLevel == null)
            {
                MessageBox.Show("Пожалуйста, выберите уровень для удаления.");
                return;
            }

            int levelId = selectedLevel.Value;

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string deleteSql = "DELETE FROM education_levels WHERE Id = @Id";
                    using (var command = new NpgsqlCommand(deleteSql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", levelId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Уровень успешно удален.");
                LoadLevels();  // Обновляем список уровней
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении уровня: " + ex.Message);
            }
        }

        private void btnDeleteDirection_Click(object sender, EventArgs e)
        {
            if (dataGridViewDirections.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите направление для удаления.");
                return;
            }

            int directionId = (int)dataGridViewDirections.SelectedRows[0].Cells[0].Value;

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string deleteSql = "DELETE FROM directions WHERE Id = @Id";
                    using (var command = new NpgsqlCommand(deleteSql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", directionId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Направление успешно удалено.");
                var selectedLevel = comboBoxLevels.SelectedItem as dynamic;
                if (selectedLevel != null)
                {
                    LoadDirections(selectedLevel.Value);  // Обновляем список направлений
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении направления: " + ex.Message);
            }
        }

        private void dataGridViewDirections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
