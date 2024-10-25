namespace BankSystem.Views
{
    partial class WithdrawForm
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
            SumLabel = new Label();
            label2 = new Label();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 43);
            label1.TabIndex = 4;
            label1.Text = "提现";
            // 
            // SumLabel
            // 
            SumLabel.AutoSize = true;
            SumLabel.Font = new Font("Microsoft YaHei UI", 15.8571434F, FontStyle.Bold, GraphicsUnit.Point, 134);
            SumLabel.Location = new Point(12, 104);
            SumLabel.Name = "SumLabel";
            SumLabel.Size = new Size(125, 50);
            SumLabel.TabIndex = 5;
            SumLabel.Text = "$0.00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(306, 28);
            label2.TabIndex = 6;
            label2.Text = "在键盘上键入金额，按回车确定";
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(360, 159);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(131, 40);
            CancelButton.TabIndex = 7;
            CancelButton.TabStop = false;
            CancelButton.Text = "取消";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // WithdrawForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 211);
            ControlBox = false;
            Controls.Add(CancelButton);
            Controls.Add(label2);
            Controls.Add(SumLabel);
            Controls.Add(label1);
            Name = "WithdrawForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "提现";
            KeyPress += WithdrawForm_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label SumLabel;
        private Label label2;
        private Button CancelButton;
    }
}