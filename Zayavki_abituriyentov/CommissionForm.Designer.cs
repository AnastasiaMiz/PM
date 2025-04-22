namespace Zayavki_abituriyentov
{
    partial class CommissionForm
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
            components = new System.ComponentModel.Container();
            btnChangeStatus = new Button();
            txtComment = new TextBox();
            dataGridViewApplications = new DataGridView();
            admissionApplicationBindingSource = new BindingSource(components);
            comboBoxStatus = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            buttonLvlDir = new Button();
            btnExportToCSV = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewApplications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)admissionApplicationBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Location = new Point(43, 495);
            btnChangeStatus.Margin = new Padding(3, 4, 3, 4);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(133, 40);
            btnChangeStatus.TabIndex = 0;
            btnChangeStatus.Text = "Изменить";
            btnChangeStatus.UseVisualStyleBackColor = true;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(504, 416);
            txtComment.Margin = new Padding(3, 4, 3, 4);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.PlaceholderText = "Комментарий";
            txtComment.Size = new Size(282, 28);
            txtComment.TabIndex = 2;
            // 
            // dataGridViewApplications
            // 
            dataGridViewApplications.AutoGenerateColumns = false;
            dataGridViewApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewApplications.DataSource = admissionApplicationBindingSource;
            dataGridViewApplications.Location = new Point(43, 133);
            dataGridViewApplications.Margin = new Padding(3, 4, 3, 4);
            dataGridViewApplications.Name = "dataGridViewApplications";
            dataGridViewApplications.RowHeadersWidth = 51;
            dataGridViewApplications.RowTemplate.Height = 24;
            dataGridViewApplications.Size = new Size(743, 232);
            dataGridViewApplications.TabIndex = 3;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(43, 416);
            comboBoxStatus.Margin = new Padding(3, 4, 3, 4);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(248, 28);
            comboBoxStatus.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(233, 46);
            label1.Name = "label1";
            label1.Size = new Size(353, 50);
            label1.TabIndex = 5;
            label1.Text = "Обработка заявок";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 392);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 6;
            label2.Text = "Измените статус";
            // 
            // buttonLvlDir
            // 
            buttonLvlDir.Location = new Point(476, 495);
            buttonLvlDir.Name = "buttonLvlDir";
            buttonLvlDir.Size = new Size(310, 40);
            buttonLvlDir.TabIndex = 7;
            buttonLvlDir.Text = "Добавить уровень или направление ";
            buttonLvlDir.UseVisualStyleBackColor = true;
            buttonLvlDir.Click += buttonLvlDir_Click;
            // 
            // btnExportToCSV
            // 
            btnExportToCSV.Location = new Point(311, 495);
            btnExportToCSV.Name = "btnExportToCSV";
            btnExportToCSV.Size = new Size(159, 40);
            btnExportToCSV.TabIndex = 8;
            btnExportToCSV.Text = "Сохранить отчёт";
            btnExportToCSV.UseVisualStyleBackColor = true;
            btnExportToCSV.Click += btnExportToCSV_Click;
            // 
            // CommissionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(834, 562);
            Controls.Add(btnExportToCSV);
            Controls.Add(buttonLvlDir);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxStatus);
            Controls.Add(dataGridViewApplications);
            Controls.Add(txtComment);
            Controls.Add(btnChangeStatus);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CommissionForm";
            Text = "CommissionForm";
            Load += CommissionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewApplications).EndInit();
            ((System.ComponentModel.ISupportInitialize)admissionApplicationBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.DataGridView dataGridViewApplications;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private DataGridViewTextBoxColumn abiturientIdDataGridViewTextBoxColumn;
        private BindingSource admissionApplicationBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn abiturientFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn submissionDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private Label label1;
        private Label label2;
        private Button buttonLvlDir;
        private Button btnExportToCSV;
    }
}