using System.ComponentModel;
using System.Text;
using BankSystem.Models;

namespace BankSystem
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && ValidatePassword())
            {
                var repsonse = Shared.Database.RegisterAccount(
                    new Account
                    {
                        AccountId = Guid.NewGuid().ToString("N"),
                        LoginName = LoginNameBox.Text,
                        Name = NameBox.Text,
                        Pronouns = PronounsBox.Text,
                    },
                    PasswordBox.Text.ComputeMd5()
                );
                if (repsonse.Success)
                {
                    MessageBox.Show("注册成功，将返回登陆。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show(repsonse.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show("请输入姓名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(LoginNameBox.Text))
            {
                MessageBox.Show("请输入登录名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(PronounsBox.Text))
            {
                MessageBox.Show("请输入称呼", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidatePassword()
        {
#if DEBUG
            if (PasswordBox.Text == "gbc")
                return true;
#endif
            if (PasswordBox.Text != RepeatPasswordBox.Text)
            {
                MessageBox.Show("两次输入的密码不一致", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PasswordBox.Text.Length < 8)
            {
                MessageBox.Show("密码长度必须大于等于 8", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PasswordBox.Text.Any(char.IsUpper) == false)
            {
                MessageBox.Show("密码必须包含至少一个大写字母", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PasswordBox.Text.Any(char.IsLower) == false)
            {
                MessageBox.Show("密码必须包含至少一个小写字母", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PasswordBox.Text.Any(char.IsDigit) == false)
            {
                MessageBox.Show("密码必须包含至少一个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PasswordBox.Text.Any(char.IsPunctuation) == false)
            {
                MessageBox.Show("密码必须包含至少一个特殊字符", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void PasswordBox_Validating(object sender, CancelEventArgs e)
        {
#if DEBUG
            if (PasswordBox.Text == "gbc")
            {
                errorProvider1.SetError(PasswordBox, null);
                return;
            }
#endif
            StringBuilder sb = new StringBuilder();
            if (PasswordBox.Text.Length < 8)
            {
                sb.AppendLine("密码长度必须大于等于 8");
            }
            if (PasswordBox.Text.Any(char.IsUpper) == false)
            {
                sb.AppendLine("密码必须包含至少一个大写字母");
            }
            if (PasswordBox.Text.Any(char.IsLower) == false)
            {
                sb.AppendLine("密码必须包含至少一个小写字母");
            }
            if (PasswordBox.Text.Any(char.IsDigit) == false)
            {
                sb.AppendLine("密码必须包含至少一个数字");
            }
            if (PasswordBox.Text.Any(char.IsPunctuation) == false)
            {
                sb.AppendLine("密码必须包含至少一个特殊字符");
            }
            if (sb.Length > 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(PasswordBox, sb.ToString());
            }
            else
            {
                errorProvider1.SetError(PasswordBox, null);
            }
        }

        private void RepeatPasswordBox_Validating(object sender, CancelEventArgs e)
        {
            if (RepeatPasswordBox.Text != PasswordBox.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(RepeatPasswordBox, "两次输入的密码不一致");
            }
        }

        private void RepeatPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                RegisterButton.PerformClick();
            }
        }
    }
}
