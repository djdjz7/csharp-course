namespace BankSystem.Views
{
    partial class InputForm
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
            PasswordBox = new TextBox();
            ConfirmButton = new Button();
            HintLabel = new Label();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(168, 48);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "密码验证";
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(12, 110);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(405, 38);
            PasswordBox.TabIndex = 1;
            PasswordBox.UseSystemPasswordChar = true;
            PasswordBox.KeyPress += PasswordBox_KeyPress;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ConfirmButton.Location = new Point(267, 189);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(150, 46);
            ConfirmButton.TabIndex = 2;
            ConfirmButton.Text = "确定";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // HintLabel
            // 
            HintLabel.AutoSize = true;
            HintLabel.Location = new Point(12, 76);
            HintLabel.Name = "HintLabel";
            HintLabel.Size = new Size(206, 31);
            HintLabel.TabIndex = 3;
            HintLabel.Text = "请输入管理员密码";
            // 
            // InputPasswordForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 247);
            ControlBox = false;
            Controls.Add(HintLabel);
            Controls.Add(ConfirmButton);
            Controls.Add(PasswordBox);
            Controls.Add(TitleLabel);
            Name = "InputPasswordForm";
            Text = "密码验证";
            Load += InputPasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private TextBox PasswordBox;
        private Button ConfirmButton;
        private Label label2;
        private Label HintLabel;
    }
}