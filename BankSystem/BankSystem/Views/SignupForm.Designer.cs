namespace BankSystem
{
    partial class SignupForm
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
            label1 = new Label();
            PasswordBox = new TextBox();
            RepeatPasswordBox = new TextBox();
            RegisterButton = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            NameBox = new TextBox();
            PronounsBox = new ComboBox();
            label5 = new Label();
            LoginNameBox = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(11, 8);
            label1.Name = "label1";
            label1.Size = new Size(85, 43);
            label1.TabIndex = 0;
            label1.Text = "注册";
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(11, 277);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(329, 34);
            PasswordBox.TabIndex = 4;
            PasswordBox.UseSystemPasswordChar = true;
            PasswordBox.Validating += PasswordBox_Validating;
            // 
            // RepeatPasswordBox
            // 
            RepeatPasswordBox.Location = new Point(11, 368);
            RepeatPasswordBox.Name = "RepeatPasswordBox";
            RepeatPasswordBox.Size = new Size(329, 34);
            RepeatPasswordBox.TabIndex = 5;
            RepeatPasswordBox.UseSystemPasswordChar = true;
            RepeatPasswordBox.KeyPress += RepeatPasswordBox_KeyPress;
            RepeatPasswordBox.Validating += RepeatPasswordBox_Validating;
            // 
            // RegisterButton
            // 
            RegisterButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RegisterButton.Location = new Point(243, 422);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(139, 42);
            RegisterButton.TabIndex = 6;
            RegisterButton.Text = "注册";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 337);
            label4.Name = "label4";
            label4.Size = new Size(96, 28);
            label4.TabIndex = 6;
            label4.Text = "重复密码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 247);
            label3.Name = "label3";
            label3.Size = new Size(54, 28);
            label3.TabIndex = 5;
            label3.Text = "密码";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 67);
            label2.Name = "label2";
            label2.Size = new Size(54, 28);
            label2.TabIndex = 7;
            label2.Text = "姓名";
            // 
            // NameBox
            // 
            NameBox.Location = new Point(11, 98);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(186, 34);
            NameBox.TabIndex = 1;
            // 
            // PronounsBox
            // 
            PronounsBox.FormattingEnabled = true;
            PronounsBox.Items.AddRange(new object[] { "先生", "女士", "武装直升机", "沃尔玛购物袋" });
            PronounsBox.Location = new Point(202, 98);
            PronounsBox.Name = "PronounsBox";
            PronounsBox.Size = new Size(138, 36);
            PronounsBox.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 154);
            label5.Name = "label5";
            label5.Size = new Size(117, 28);
            label5.TabIndex = 10;
            label5.Text = "登录用户名";
            // 
            // LoginNameBox
            // 
            LoginNameBox.Location = new Point(11, 185);
            LoginNameBox.Name = "LoginNameBox";
            LoginNameBox.Size = new Size(329, 34);
            LoginNameBox.TabIndex = 3;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 474);
            Controls.Add(LoginNameBox);
            Controls.Add(label5);
            Controls.Add(PronounsBox);
            Controls.Add(NameBox);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(RegisterButton);
            Controls.Add(RepeatPasswordBox);
            Controls.Add(PasswordBox);
            Controls.Add(label1);
            Name = "SignupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "注册";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox PasswordBox;
        private TextBox RepeatPasswordBox;
        private Button RegisterButton;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox NameBox;
        private ComboBox PronounsBox;
        private Label label5;
        private TextBox LoginNameBox;
        private ErrorProvider errorProvider1;
    }
}