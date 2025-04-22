namespace Zayavki_abituriyentov
{
    partial class LoginForm
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
            btnLogin = new Button();
            btnRegister = new Button();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            btnRegisterCommission = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLogin.Location = new Point(286, 165);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(72, 42);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(35, 238);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(323, 29);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Регистрация абитуриента";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(37, 102);
            txtLogin.Margin = new Padding(3, 4, 3, 4);
            txtLogin.Multiline = true;
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Логин";
            txtLogin.Size = new Size(207, 42);
            txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(35, 165);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Пароль";
            txtPassword.Size = new Size(207, 42);
            txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(35, 36);
            label1.Name = "label1";
            label1.Size = new Size(91, 41);
            label1.TabIndex = 4;
            label1.Text = "Вход";
            // 
            // btnRegisterCommission
            // 
            btnRegisterCommission.Location = new Point(35, 287);
            btnRegisterCommission.Name = "btnRegisterCommission";
            btnRegisterCommission.Size = new Size(323, 29);
            btnRegisterCommission.TabIndex = 5;
            btnRegisterCommission.Text = "Регистрация представителя комиссии";
            btnRegisterCommission.UseVisualStyleBackColor = true;
            btnRegisterCommission.Click += btnRegisterCommission_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(388, 336);
            Controls.Add(btnRegisterCommission);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            ForeColor = Color.Black;
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private Label label1;
        private Button btnRegisterCommission;
    }
}