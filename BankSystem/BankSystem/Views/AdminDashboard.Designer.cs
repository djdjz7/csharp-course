namespace BankSystem.Views
{
    partial class AdminDashboard
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
            StartUserSpaceButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ChangeAdminPasswordButton = new Button();
            AccountSumLabel = new Label();
            CapticalSumLabel = new Label();
            AlarmSumLabel = new Label();
            ViewUsersButton = new Button();
            QuitButton = new Button();
            SuspendLayout();
            // 
            // StartUserSpaceButton
            // 
            StartUserSpaceButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StartUserSpaceButton.AutoSize = true;
            StartUserSpaceButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartUserSpaceButton.Location = new Point(13, 294);
            StartUserSpaceButton.Name = "StartUserSpaceButton";
            StartUserSpaceButton.Size = new Size(168, 41);
            StartUserSpaceButton.TabIndex = 0;
            StartUserSpaceButton.Text = "启动用户空间";
            StartUserSpaceButton.UseVisualStyleBackColor = true;
            StartUserSpaceButton.Click += StartUserSpaceButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(221, 50);
            label1.TabIndex = 1;
            label1.Text = "Dashboard";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 84);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 2;
            label2.Text = "用户总数";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(419, 84);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 3;
            label3.Text = "银行总资产";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 84);
            label4.Name = "label4";
            label4.Size = new Size(110, 31);
            label4.TabIndex = 4;
            label4.Text = "预警总数";
            // 
            // ChangeAdminPasswordButton
            // 
            ChangeAdminPasswordButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ChangeAdminPasswordButton.AutoSize = true;
            ChangeAdminPasswordButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ChangeAdminPasswordButton.Location = new Point(187, 294);
            ChangeAdminPasswordButton.Name = "ChangeAdminPasswordButton";
            ChangeAdminPasswordButton.Size = new Size(192, 41);
            ChangeAdminPasswordButton.TabIndex = 5;
            ChangeAdminPasswordButton.Text = "修改管理员密码";
            ChangeAdminPasswordButton.UseVisualStyleBackColor = true;
            ChangeAdminPasswordButton.Click += ChangeAdminPasswordButton_Click;
            // 
            // AccountSumLabel
            // 
            AccountSumLabel.AutoSize = true;
            AccountSumLabel.Font = new Font("Microsoft YaHei UI", 16.125F, FontStyle.Bold);
            AccountSumLabel.Location = new Point(12, 124);
            AccountSumLabel.Name = "AccountSumLabel";
            AccountSumLabel.Size = new Size(52, 57);
            AccountSumLabel.TabIndex = 6;
            AccountSumLabel.Text = "0";
            // 
            // CapticalSumLabel
            // 
            CapticalSumLabel.AutoSize = true;
            CapticalSumLabel.Font = new Font("Microsoft YaHei UI", 16.125F, FontStyle.Bold);
            CapticalSumLabel.Location = new Point(419, 124);
            CapticalSumLabel.Name = "CapticalSumLabel";
            CapticalSumLabel.Size = new Size(52, 57);
            CapticalSumLabel.TabIndex = 7;
            CapticalSumLabel.Text = "0";
            // 
            // AlarmSumLabel
            // 
            AlarmSumLabel.AutoSize = true;
            AlarmSumLabel.Font = new Font("Microsoft YaHei UI", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 134);
            AlarmSumLabel.Location = new Point(212, 124);
            AlarmSumLabel.Name = "AlarmSumLabel";
            AlarmSumLabel.Size = new Size(52, 57);
            AlarmSumLabel.TabIndex = 8;
            AlarmSumLabel.Text = "0";
            // 
            // ViewUsersButton
            // 
            ViewUsersButton.AutoSize = true;
            ViewUsersButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ViewUsersButton.Location = new Point(12, 184);
            ViewUsersButton.Name = "ViewUsersButton";
            ViewUsersButton.Size = new Size(120, 41);
            ViewUsersButton.TabIndex = 9;
            ViewUsersButton.Text = "查看用户";
            ViewUsersButton.TextAlign = ContentAlignment.MiddleLeft;
            ViewUsersButton.UseVisualStyleBackColor = true;
            ViewUsersButton.Click += ViewUsersButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.AutoSize = true;
            QuitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            QuitButton.Location = new Point(385, 294);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(120, 41);
            QuitButton.TabIndex = 10;
            QuitButton.Text = "退出系统";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(638, 348);
            ControlBox = false;
            Controls.Add(QuitButton);
            Controls.Add(ViewUsersButton);
            Controls.Add(AlarmSumLabel);
            Controls.Add(CapticalSumLabel);
            Controls.Add(AccountSumLabel);
            Controls.Add(ChangeAdminPasswordButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(StartUserSpaceButton);
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            Load += AdminDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartUserSpaceButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button ChangeAdminPasswordButton;
        private Label AccountSumLabel;
        private Label CapticalSumLabel;
        private Label AlarmSumLabel;
        private Button ViewUsersButton;
        private Button QuitButton;
    }
}