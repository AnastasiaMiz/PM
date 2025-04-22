namespace Zayavki_abituriyentov
{
    partial class RegisterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            comboBoxLevel = new ComboBox();
            checkedListBoxDirections = new CheckedListBox();
            btnRegister = new Button();
            label1 = new Label();
            txtPassportData = new TextBox();
            txtSnils = new TextBox();
            txtParentName = new TextBox();
            txtSchool = new TextBox();
            txtAverageScore = new TextBox();
            txtDocumentUrl = new TextBox();
            label2 = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(37, 97);
            txtFullName.Multiline = true;
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "ФИО";
            txtFullName.Size = new Size(250, 42);
            txtFullName.TabIndex = 0;
            txtFullName.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(37, 164);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Электронная почта";
            txtEmail.Size = new Size(250, 42);
            txtEmail.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(37, 236);
            txtPhone.Multiline = true;
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Телефон";
            txtPhone.Size = new Size(250, 42);
            txtPhone.TabIndex = 2;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // comboBoxLevel
            // 
            comboBoxLevel.FormattingEnabled = true;
            comboBoxLevel.Location = new Point(370, 379);
            comboBoxLevel.Name = "comboBoxLevel";
            comboBoxLevel.Size = new Size(396, 28);
            comboBoxLevel.TabIndex = 3;
            comboBoxLevel.SelectedIndexChanged += comboBoxLevel_SelectedIndexChanged;
            // 
            // checkedListBoxDirections
            // 
            checkedListBoxDirections.FormattingEnabled = true;
            checkedListBoxDirections.Location = new Point(370, 457);
            checkedListBoxDirections.Name = "checkedListBoxDirections";
            checkedListBoxDirections.Size = new Size(396, 180);
            checkedListBoxDirections.TabIndex = 4;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRegister.Location = new Point(580, 670);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(186, 45);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(33, 30);
            label1.Name = "label1";
            label1.Size = new Size(531, 41);
            label1.TabIndex = 6;
            label1.Text = "Подача заявки              Регистрация\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPassportData
            // 
            txtPassportData.Location = new Point(36, 309);
            txtPassportData.Multiline = true;
            txtPassportData.Name = "txtPassportData";
            txtPassportData.PlaceholderText = "Паспортные данные";
            txtPassportData.Size = new Size(251, 40);
            txtPassportData.TabIndex = 7;
            txtPassportData.TextChanged += txtPassportData_TextChanged;
            // 
            // txtSnils
            // 
            txtSnils.Location = new Point(36, 379);
            txtSnils.Multiline = true;
            txtSnils.Name = "txtSnils";
            txtSnils.PlaceholderText = "СНИЛС";
            txtSnils.Size = new Size(251, 40);
            txtSnils.TabIndex = 8;
            // 
            // txtParentName
            // 
            txtParentName.Location = new Point(36, 450);
            txtParentName.Multiline = true;
            txtParentName.Name = "txtParentName";
            txtParentName.PlaceholderText = "ФИО родителя";
            txtParentName.Size = new Size(251, 40);
            txtParentName.TabIndex = 9;
            // 
            // txtSchool
            // 
            txtSchool.Location = new Point(36, 523);
            txtSchool.Multiline = true;
            txtSchool.Name = "txtSchool";
            txtSchool.PlaceholderText = "Оконченное учебное заведение";
            txtSchool.Size = new Size(251, 40);
            txtSchool.TabIndex = 10;
            // 
            // txtAverageScore
            // 
            txtAverageScore.Location = new Point(36, 597);
            txtAverageScore.Multiline = true;
            txtAverageScore.Name = "txtAverageScore";
            txtAverageScore.PlaceholderText = "Средний балл";
            txtAverageScore.Size = new Size(251, 40);
            txtAverageScore.TabIndex = 11;
            // 
            // txtDocumentUrl
            // 
            txtDocumentUrl.Location = new Point(36, 670);
            txtDocumentUrl.Multiline = true;
            txtDocumentUrl.Name = "txtDocumentUrl";
            txtDocumentUrl.PlaceholderText = "Скан документа об образовании";
            txtDocumentUrl.Size = new Size(251, 40);
            txtDocumentUrl.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 434);
            label2.Name = "label2";
            label2.Size = new Size(249, 20);
            label2.TabIndex = 13;
            label2.Text = "Выберите направление (от 1 до 5)";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(370, 122);
            txtLogin.Multiline = true;
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Логин";
            txtLogin.Size = new Size(263, 42);
            txtLogin.TabIndex = 14;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(370, 189);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Пороль";
            txtPassword.Size = new Size(263, 42);
            txtPassword.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(370, 99);
            label3.Name = "label3";
            label3.Size = new Size(203, 20);
            label3.TabIndex = 16;
            label3.Text = "Придумайте логин и парль ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(370, 356);
            label4.Name = "label4";
            label4.Size = new Size(237, 20);
            label4.TabIndex = 17;
            label4.Text = "Выберите уровень образования";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(800, 731);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(label2);
            Controls.Add(txtDocumentUrl);
            Controls.Add(txtAverageScore);
            Controls.Add(txtSchool);
            Controls.Add(txtParentName);
            Controls.Add(txtSnils);
            Controls.Add(txtPassportData);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(checkedListBoxDirections);
            Controls.Add(comboBoxLevel);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private ComboBox comboBoxLevel;
        private CheckedListBox checkedListBoxDirections;
        private Button btnRegister;
        private Label label1;
        private TextBox txtPassportData;
        private TextBox txtSnils;
        private TextBox txtParentName;
        private TextBox txtSchool;
        private TextBox txtAverageScore;
        private TextBox txtDocumentUrl;
        private Label label2;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Label label3;
        private Label label4;
    }
}
