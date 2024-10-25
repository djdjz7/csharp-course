namespace BankSystem.Views
{
    partial class SetAdminPasswordForm
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
            OldPasswordBox = new TextBox();
            OldPasswordLabel = new Label();
            label3 = new Label();
            label4 = new Label();
            NewPasswordBox = new TextBox();
            RepeatPasswordBox = new TextBox();
            ConfirmButton = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(288, 50);
            label1.TabIndex = 0;
            label1.Text = "设置管理员密码";
            // 
            // OldPasswordBox
            // 
            OldPasswordBox.Enabled = false;
            OldPasswordBox.Location = new Point(13, 110);
            OldPasswordBox.Name = "OldPasswordBox";
            OldPasswordBox.Size = new Size(306, 38);
            OldPasswordBox.TabIndex = 1;
            OldPasswordBox.UseSystemPasswordChar = true;
            OldPasswordBox.KeyPress += OldPasswordBox_KeyPress;
            // 
            // OldPasswordLabel
            // 
            OldPasswordLabel.AutoSize = true;
            OldPasswordLabel.Location = new Point(13, 75);
            OldPasswordLabel.Name = "OldPasswordLabel";
            OldPasswordLabel.Size = new Size(86, 31);
            OldPasswordLabel.TabIndex = 2;
            OldPasswordLabel.Text = "原密码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 170);
            label3.Name = "label3";
            label3.Size = new Size(86, 31);
            label3.TabIndex = 3;
            label3.Text = "新密码";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 270);
            label4.Name = "label4";
            label4.Size = new Size(134, 31);
            label4.TabIndex = 4;
            label4.Text = "重复新密码";
            // 
            // NewPasswordBox
            // 
            NewPasswordBox.Location = new Point(13, 205);
            NewPasswordBox.Name = "NewPasswordBox";
            NewPasswordBox.Size = new Size(306, 38);
            NewPasswordBox.TabIndex = 5;
            NewPasswordBox.UseSystemPasswordChar = true;
            NewPasswordBox.KeyPress += NewPasswordBox_KeyPress;
            NewPasswordBox.Validating += NewPasswordBox_Validating;
            // 
            // RepeatPasswordBox
            // 
            RepeatPasswordBox.Location = new Point(13, 304);
            RepeatPasswordBox.Name = "RepeatPasswordBox";
            RepeatPasswordBox.Size = new Size(306, 38);
            RepeatPasswordBox.TabIndex = 6;
            RepeatPasswordBox.UseSystemPasswordChar = true;
            RepeatPasswordBox.KeyPress += RepeatPasswordBox_KeyPress;
            RepeatPasswordBox.Validating += RepeatPasswordBox_Validating;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ConfirmButton.Location = new Point(223, 393);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(141, 44);
            ConfirmButton.TabIndex = 7;
            ConfirmButton.Text = "完成";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // SetAdminPassword
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 451);
            ControlBox = false;
            Controls.Add(ConfirmButton);
            Controls.Add(RepeatPasswordBox);
            Controls.Add(NewPasswordBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(OldPasswordLabel);
            Controls.Add(OldPasswordBox);
            Controls.Add(label1);
            Name = "SetAdminPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "设置管理员密码";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox OldPasswordBox;
        private Label OldPasswordLabel;
        private Label label3;
        private Label label4;
        private TextBox NewPasswordBox;
        private TextBox RepeatPasswordBox;
        private Button ConfirmButton;
        private ErrorProvider errorProvider1;
    }
}