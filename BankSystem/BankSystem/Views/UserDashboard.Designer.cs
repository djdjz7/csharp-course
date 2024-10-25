namespace BankSystem.Views
{
    partial class UserDashboard
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
            WelcomeBackLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            BalanceLabel = new Label();
            StartTransactionButton = new Button();
            DepositButton = new Button();
            WithdrawButton = new Button();
            BalanceDetailsButton = new Button();
            LogoutButton = new Button();
            LastTransactionLabel = new Label();
            SuspendLayout();
            // 
            // WelcomeBackLabel
            // 
            WelcomeBackLabel.AutoSize = true;
            WelcomeBackLabel.Location = new Point(12, 59);
            WelcomeBackLabel.Name = "WelcomeBackLabel";
            WelcomeBackLabel.Size = new Size(134, 31);
            WelcomeBackLabel.TabIndex = 0;
            WelcomeBackLabel.Text = "欢迎回来，";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(221, 50);
            label1.TabIndex = 2;
            label1.Text = "Dashboard";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 123);
            label2.Name = "label2";
            label2.Size = new Size(86, 31);
            label2.TabIndex = 3;
            label2.Text = "总资产";
            // 
            // BalanceLabel
            // 
            BalanceLabel.AutoSize = true;
            BalanceLabel.Font = new Font("Microsoft YaHei UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 134);
            BalanceLabel.Location = new Point(12, 162);
            BalanceLabel.Name = "BalanceLabel";
            BalanceLabel.Size = new Size(52, 57);
            BalanceLabel.TabIndex = 4;
            BalanceLabel.Text = "0";
            // 
            // StartTransactionButton
            // 
            StartTransactionButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StartTransactionButton.Location = new Point(369, 183);
            StartTransactionButton.Name = "StartTransactionButton";
            StartTransactionButton.Size = new Size(150, 46);
            StartTransactionButton.TabIndex = 5;
            StartTransactionButton.Text = "发起转账";
            StartTransactionButton.UseVisualStyleBackColor = true;
            StartTransactionButton.Click += StartTransactionButton_Click;
            // 
            // DepositButton
            // 
            DepositButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DepositButton.Location = new Point(370, 235);
            DepositButton.Name = "DepositButton";
            DepositButton.Size = new Size(150, 46);
            DepositButton.TabIndex = 6;
            DepositButton.Text = "存入";
            DepositButton.UseVisualStyleBackColor = true;
            DepositButton.Click += DepositButton_Click;
            // 
            // WithdrawButton
            // 
            WithdrawButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            WithdrawButton.Location = new Point(369, 287);
            WithdrawButton.Name = "WithdrawButton";
            WithdrawButton.Size = new Size(150, 46);
            WithdrawButton.TabIndex = 7;
            WithdrawButton.Text = "提现";
            WithdrawButton.UseVisualStyleBackColor = true;
            WithdrawButton.Click += WithdrawButton_Click;
            // 
            // BalanceDetailsButton
            // 
            BalanceDetailsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BalanceDetailsButton.Location = new Point(12, 290);
            BalanceDetailsButton.Name = "BalanceDetailsButton";
            BalanceDetailsButton.Size = new Size(150, 46);
            BalanceDetailsButton.TabIndex = 8;
            BalanceDetailsButton.Text = "资产详情";
            BalanceDetailsButton.UseVisualStyleBackColor = true;
            BalanceDetailsButton.Click += BalanceDetailsButton_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LogoutButton.Location = new Point(370, 15);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(150, 46);
            LogoutButton.TabIndex = 9;
            LogoutButton.Text = "退出登录";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // LastTransactionLabel
            // 
            LastTransactionLabel.AutoSize = true;
            LastTransactionLabel.Location = new Point(12, 219);
            LastTransactionLabel.Name = "LastTransactionLabel";
            LastTransactionLabel.Size = new Size(82, 31);
            LastTransactionLabel.TabIndex = 10;
            LastTransactionLabel.Text = "label3";
            // 
            // UserDashboard
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 349);
            ControlBox = false;
            Controls.Add(LastTransactionLabel);
            Controls.Add(LogoutButton);
            Controls.Add(BalanceDetailsButton);
            Controls.Add(WithdrawButton);
            Controls.Add(DepositButton);
            Controls.Add(StartTransactionButton);
            Controls.Add(BalanceLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(WelcomeBackLabel);
            Name = "UserDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += UserDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WelcomeBackLabel;
        private Label label1;
        private Label label2;
        private Label BalanceLabel;
        private Button StartTransactionButton;
        private Button DepositButton;
        private Button WithdrawButton;
        private Button BalanceDetailsButton;
        private Button LogoutButton;
        private Label LastTransactionLabel;
    }
}