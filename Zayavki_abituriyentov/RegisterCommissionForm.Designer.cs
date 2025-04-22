namespace Zayavki_abituriyentov
{
    partial class RegisterCommissionForm
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
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(97, 96);
            txtFullName.Multiline = true;
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "ФИО";
            txtFullName.Size = new Size(245, 44);
            txtFullName.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(97, 165);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Электронная почта";
            txtEmail.Size = new Size(245, 44);
            txtEmail.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(97, 235);
            txtPhone.Multiline = true;
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Телефон";
            txtPhone.Size = new Size(245, 44);
            txtPhone.TabIndex = 2;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(97, 304);
            txtLogin.Multiline = true;
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Логин";
            txtLogin.Size = new Size(245, 44);
            txtLogin.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(97, 376);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Пароль";
            txtPassword.Size = new Size(245, 44);
            txtPassword.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(34, 34);
            label1.Name = "label1";
            label1.Size = new Size(385, 31);
            label1.TabIndex = 5;
            label1.Text = "Регистрация сотудника комиссии";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRegister.Location = new Point(129, 468);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(178, 37);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterCommissionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(452, 538);
            Controls.Add(btnRegister);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Name = "RegisterCommissionForm";
            Text = "RegisterCommissionForm";
            Load += RegisterCommissionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Label label1;
        private Button btnRegister;
    }
}