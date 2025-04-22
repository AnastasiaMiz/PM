namespace Zayavki_abituriyentov
{
    partial class AbiturientForm
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
            lblStatus = new Label();
            btnUpdateStatus = new Button();
            btnPrintApplication = new Button();
            txtFullName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(33, 186);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(103, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Статус заявки";
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(33, 230);
            btnUpdateStatus.Margin = new Padding(3, 4, 3, 4);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(208, 29);
            btnUpdateStatus.TabIndex = 1;
            btnUpdateStatus.Text = "Обновить статус";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // btnPrintApplication
            // 
            btnPrintApplication.Location = new Point(33, 278);
            btnPrintApplication.Margin = new Padding(3, 4, 3, 4);
            btnPrintApplication.Name = "btnPrintApplication";
            btnPrintApplication.Size = new Size(208, 29);
            btnPrintApplication.TabIndex = 2;
            btnPrintApplication.Text = "Распечатать заявление";
            btnPrintApplication.UseVisualStyleBackColor = true;
            btnPrintApplication.Click += btnPrintApplication_Click;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(33, 113);
            txtFullName.Multiline = true;
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "фИО";
            txtFullName.Size = new Size(277, 41);
            txtFullName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(33, 38);
            label1.Name = "label1";
            label1.Size = new Size(274, 41);
            label1.TabIndex = 4;
            label1.Text = "Просмотр заявки";
            // 
            // AbiturientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(369, 350);
            Controls.Add(label1);
            Controls.Add(txtFullName);
            Controls.Add(btnPrintApplication);
            Controls.Add(btnUpdateStatus);
            Controls.Add(lblStatus);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AbiturientForm";
            Text = "AbiturientForm";
            Load += AbiturientForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnPrintApplication;
        private TextBox txtFullName;
        private Label label1;
    }
}