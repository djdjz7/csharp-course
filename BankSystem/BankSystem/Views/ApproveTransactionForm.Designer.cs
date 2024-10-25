namespace BankSystem.Views
{
    partial class ApproveTransactionForm
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
            FromAccountDetails = new Label();
            ToAccountDetails = new Label();
            label6 = new Label();
            label7 = new Label();
            AmountLabel = new Label();
            DenyButton = new Button();
            ApproveButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(168, 48);
            label1.TabIndex = 0;
            label1.Text = "批准转账";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(662, 62);
            label2.TabIndex = 1;
            label2.Text = "风控系统发现了一起可疑转账，转入方在一天内有大额进账。\r\n该转账已被拦截，请管理员选择批准或拒绝";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label3.Location = new Point(12, 278);
            label3.Name = "label3";
            label3.Size = new Size(86, 31);
            label3.TabIndex = 2;
            label3.Text = "转出方";
            // 
            // FromAccountDetails
            // 
            FromAccountDetails.AutoSize = true;
            FromAccountDetails.Location = new Point(12, 309);
            FromAccountDetails.Name = "FromAccountDetails";
            FromAccountDetails.Size = new Size(369, 124);
            FromAccountDetails.TabIndex = 3;
            FromAccountDetails.Text = "姓名：1\r\n登录名：1\r\nAccount ID：1\r\n转账时间：2024-10-25 12:22:00";
            // 
            // ToAccountDetails
            // 
            ToAccountDetails.AutoSize = true;
            ToAccountDetails.Location = new Point(647, 309);
            ToAccountDetails.Name = "ToAccountDetails";
            ToAccountDetails.Size = new Size(266, 124);
            ToAccountDetails.TabIndex = 4;
            ToAccountDetails.Text = "姓名：1\r\n登录名：1\r\nAccount ID：1\r\n当日进账：$100000.00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label6.Location = new Point(647, 278);
            label6.Name = "label6";
            label6.Size = new Size(86, 31);
            label6.TabIndex = 5;
            label6.Text = "转入方";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 171);
            label7.Name = "label7";
            label7.Size = new Size(110, 31);
            label7.TabIndex = 6;
            label7.Text = "转账金额";
            // 
            // AmountLabel
            // 
            AmountLabel.AutoSize = true;
            AmountLabel.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            AmountLabel.Location = new Point(12, 202);
            AmountLabel.Name = "AmountLabel";
            AmountLabel.Size = new Size(133, 52);
            AmountLabel.TabIndex = 7;
            AmountLabel.Text = "$0.00";
            // 
            // DenyButton
            // 
            DenyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DenyButton.Location = new Point(1208, 470);
            DenyButton.Name = "DenyButton";
            DenyButton.Size = new Size(150, 46);
            DenyButton.TabIndex = 8;
            DenyButton.Text = "拒绝";
            DenyButton.UseVisualStyleBackColor = true;
            DenyButton.Click += DenyButton_Click;
            // 
            // ApproveButton
            // 
            ApproveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ApproveButton.Location = new Point(1364, 470);
            ApproveButton.Name = "ApproveButton";
            ApproveButton.Size = new Size(150, 46);
            ApproveButton.TabIndex = 9;
            ApproveButton.Text = "批准";
            ApproveButton.UseVisualStyleBackColor = true;
            ApproveButton.Click += ApproveButton_Click;
            // 
            // ApproveTransactionForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1526, 528);
            ControlBox = false;
            Controls.Add(ApproveButton);
            Controls.Add(DenyButton);
            Controls.Add(AmountLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(ToAccountDetails);
            Controls.Add(FromAccountDetails);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ApproveTransactionForm";
            Text = "批准转账";
            Load += ApproveTransactionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label FromAccountDetails;
        private Label ToAccountDetails;
        private Label label6;
        private Label label7;
        private Label AmountLabel;
        private Button DenyButton;
        private Button ApproveButton;
    }
}