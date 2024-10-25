namespace BankSystem
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
            label1 = new Label();
            label2 = new Label();
            LoginNameBox = new TextBox();
            label5 = new Label();
            label3 = new Label();
            PasswordBox = new TextBox();
            RegisterButton = new Button();
            label6 = new Label();
            LoginButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 50);
            label1.TabIndex = 1;
            label1.Text = "登录";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 2;
            label2.Text = "兆京银行";
            // 
            // LoginNameBox
            // 
            LoginNameBox.Location = new Point(12, 159);
            LoginNameBox.Name = "LoginNameBox";
            LoginNameBox.Size = new Size(297, 38);
            LoginNameBox.TabIndex = 1;
            LoginNameBox.KeyPress += LoginNameBox_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 125);
            label5.Name = "label5";
            label5.Size = new Size(134, 31);
            label5.TabIndex = 14;
            label5.Text = "登录用户名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 227);
            label3.Name = "label3";
            label3.Size = new Size(62, 31);
            label3.TabIndex = 13;
            label3.Text = "密码";
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(12, 261);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(297, 38);
            PasswordBox.TabIndex = 2;
            PasswordBox.UseSystemPasswordChar = true;
            PasswordBox.KeyPress += PasswordBox_KeyPress;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(378, 253);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(150, 46);
            RegisterButton.TabIndex = 17;
            RegisterButton.Text = "前往注册";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label6.Location = new Point(378, 219);
            label6.Name = "label6";
            label6.Size = new Size(278, 31);
            label6.TabIndex = 18;
            label6.Text = "或即刻注册成为新用户！";
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(378, 151);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(150, 46);
            LoginButton.TabIndex = 19;
            LoginButton.Text = "登录";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 342);
            ControlBox = false;
            Controls.Add(LoginButton);
            Controls.Add(label6);
            Controls.Add(RegisterButton);
            Controls.Add(LoginNameBox);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(PasswordBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "登录";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox LoginNameBox;
        private Label label5;
        private Label label3;
        private TextBox PasswordBox;
        private Button RegisterButton;
        private Label label6;
        private Button LoginButton;
    }
}