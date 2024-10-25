namespace BankSystem.Views
{
    partial class DepositForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ConfirmButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(11, 8);
            label1.Name = "label1";
            label1.Size = new Size(85, 43);
            label1.TabIndex = 3;
            label1.Text = "存入";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 4;
            label2.Text = "模拟存入";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 107);
            label3.Name = "label3";
            label3.Size = new Size(138, 28);
            label3.TabIndex = 5;
            label3.Text = "已读入的金额";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 15.8571434F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label4.Location = new Point(11, 135);
            label4.Name = "label4";
            label4.Size = new Size(194, 50);
            label4.TabIndex = 6;
            label4.Text = "$5000.00";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(276, 101);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(131, 40);
            ConfirmButton.TabIndex = 7;
            ConfirmButton.Text = "存入";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(276, 147);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(131, 40);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "取消";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // DepositForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 199);
            ControlBox = false;
            Controls.Add(CancelButton);
            Controls.Add(ConfirmButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DepositForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "存入";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button ConfirmButton;
        private Button CancelButton;
    }
}