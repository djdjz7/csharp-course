namespace BankSystem.Views
{
    partial class TransactionForm
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
            TitleLabel = new Label();
            CancelButton = new Button();
            HintLabel = new Label();
            SumLabel = new Label();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Microsoft YaHei UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 134);
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(174, 50);
            TitleLabel.TabIndex = 4;
            TitleLabel.Text = "发起转账";
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(387, 178);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(141, 44);
            CancelButton.TabIndex = 10;
            CancelButton.TabStop = false;
            CancelButton.Text = "取消";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // HintLabel
            // 
            HintLabel.AutoSize = true;
            HintLabel.Location = new Point(12, 86);
            HintLabel.Name = "HintLabel";
            HintLabel.Size = new Size(350, 31);
            HintLabel.TabIndex = 9;
            HintLabel.Text = "在键盘上键入金额，按回车确定";
            // 
            // SumLabel
            // 
            SumLabel.AutoSize = true;
            SumLabel.Font = new Font("Microsoft YaHei UI", 15.8571434F, FontStyle.Bold, GraphicsUnit.Point, 134);
            SumLabel.Location = new Point(12, 117);
            SumLabel.Name = "SumLabel";
            SumLabel.Size = new Size(145, 57);
            SumLabel.TabIndex = 8;
            SumLabel.Text = "$0.00";
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 233);
            ControlBox = false;
            Controls.Add(CancelButton);
            Controls.Add(HintLabel);
            Controls.Add(SumLabel);
            Controls.Add(TitleLabel);
            Name = "TransactionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "发起转账";
            KeyPress += TransactionForm_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Button CancelButton;
        private Label HintLabel;
        private Label SumLabel;
    }
}