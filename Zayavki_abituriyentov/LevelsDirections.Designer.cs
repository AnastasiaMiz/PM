namespace Zayavki_abituriyentov
{
    partial class LevelsDirections
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxLevels = new ComboBox();
            dataGridViewDirections = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            level_id = new DataGridViewTextBoxColumn();
            txtLevelName = new TextBox();
            txtDirectionName = new TextBox();
            btnAddLevel = new Button();
            btnDeleteLevel = new Button();
            btnAddDirection = new Button();
            btnDeleteDirection = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDirections).BeginInit();
            SuspendLayout();
            // 
            // comboBoxLevels
            // 
            comboBoxLevels.DisplayMember = "name";
            comboBoxLevels.FormattingEnabled = true;
            comboBoxLevels.Location = new Point(33, 107);
            comboBoxLevels.Name = "comboBoxLevels";
            comboBoxLevels.Size = new Size(232, 28);
            comboBoxLevels.TabIndex = 0;
            comboBoxLevels.SelectedIndexChanged += comboBoxLevels_SelectedIndexChanged;
            // 
            // dataGridViewDirections
            // 
            dataGridViewDirections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDirections.Columns.AddRange(new DataGridViewColumn[] { id, name, level_id });
            dataGridViewDirections.Location = new Point(321, 107);
            dataGridViewDirections.Name = "dataGridViewDirections";
            dataGridViewDirections.RowHeadersWidth = 51;
            dataGridViewDirections.Size = new Size(491, 234);
            dataGridViewDirections.TabIndex = 1;
            dataGridViewDirections.CellContentClick += dataGridViewDirections_CellContentClick;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            id.Frozen = true;
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Visible = false;
            id.Width = 125;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            name.HeaderText = "name";
            name.MinimumWidth = 10;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 75;
            // 
            // level_id
            // 
            level_id.HeaderText = "level_id";
            level_id.MinimumWidth = 6;
            level_id.Name = "level_id";
            level_id.Visible = false;
            level_id.Width = 125;
            // 
            // txtLevelName
            // 
            txtLevelName.Location = new Point(33, 362);
            txtLevelName.Multiline = true;
            txtLevelName.Name = "txtLevelName";
            txtLevelName.PlaceholderText = "Введите уровень";
            txtLevelName.Size = new Size(213, 35);
            txtLevelName.TabIndex = 2;
            // 
            // txtDirectionName
            // 
            txtDirectionName.Location = new Point(321, 362);
            txtDirectionName.Multiline = true;
            txtDirectionName.Name = "txtDirectionName";
            txtDirectionName.PlaceholderText = "Введите направление";
            txtDirectionName.Size = new Size(491, 35);
            txtDirectionName.TabIndex = 3;
            // 
            // btnAddLevel
            // 
            btnAddLevel.ForeColor = Color.Black;
            btnAddLevel.Location = new Point(33, 412);
            btnAddLevel.Name = "btnAddLevel";
            btnAddLevel.Size = new Size(213, 29);
            btnAddLevel.TabIndex = 4;
            btnAddLevel.Text = "Добавить уровень";
            btnAddLevel.UseVisualStyleBackColor = true;
            btnAddLevel.Click += btnAddLevel_Click;
            // 
            // btnDeleteLevel
            // 
            btnDeleteLevel.ForeColor = Color.Black;
            btnDeleteLevel.Location = new Point(33, 447);
            btnDeleteLevel.Name = "btnDeleteLevel";
            btnDeleteLevel.Size = new Size(213, 29);
            btnDeleteLevel.TabIndex = 5;
            btnDeleteLevel.Text = "Удалить уровень";
            btnDeleteLevel.UseVisualStyleBackColor = true;
            btnDeleteLevel.Click += btnDeleteLevel_Click;
            // 
            // btnAddDirection
            // 
            btnAddDirection.ForeColor = Color.Black;
            btnAddDirection.Location = new Point(580, 412);
            btnAddDirection.Name = "btnAddDirection";
            btnAddDirection.Size = new Size(213, 29);
            btnAddDirection.TabIndex = 6;
            btnAddDirection.Text = "Добавить направление";
            btnAddDirection.UseVisualStyleBackColor = true;
            btnAddDirection.Click += btnAddDirection_Click;
            // 
            // btnDeleteDirection
            // 
            btnDeleteDirection.ForeColor = Color.Black;
            btnDeleteDirection.Location = new Point(580, 447);
            btnDeleteDirection.Name = "btnDeleteDirection";
            btnDeleteDirection.Size = new Size(213, 29);
            btnDeleteDirection.TabIndex = 7;
            btnDeleteDirection.Text = "Удалить направление";
            btnDeleteDirection.UseVisualStyleBackColor = true;
            btnDeleteDirection.Click += btnDeleteDirection_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(46, 26);
            label1.Name = "label1";
            label1.Size = new Size(766, 38);
            label1.TabIndex = 8;
            label1.Text = "Управление уровнями образования и направлениями";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 84);
            label2.Name = "label2";
            label2.Size = new Size(166, 20);
            label2.TabIndex = 9;
            label2.Text = "Уровень образования";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(321, 84);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 10;
            label3.Text = "Направления";
            // 
            // LevelsDirections
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(844, 503);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteDirection);
            Controls.Add(btnAddDirection);
            Controls.Add(btnDeleteLevel);
            Controls.Add(btnAddLevel);
            Controls.Add(txtDirectionName);
            Controls.Add(txtLevelName);
            Controls.Add(dataGridViewDirections);
            Controls.Add(comboBoxLevels);
            ForeColor = Color.MidnightBlue;
            Name = "LevelsDirections";
            Text = "LevelsDirections";
            Load += LevelsDirections_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDirections).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxLevels;
        private DataGridView dataGridViewDirections;
        private TextBox txtLevelName;
        private TextBox txtDirectionName;
        private Button btnAddLevel;
        private Button btnDeleteLevel;
        private Button btnAddDirection;
        private Button btnDeleteDirection;
        private Label label1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn level_id;
        private Label label2;
        private Label label3;
    }
}