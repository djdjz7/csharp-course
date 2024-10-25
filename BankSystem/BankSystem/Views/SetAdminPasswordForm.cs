using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Views
{
    public partial class SetAdminPasswordForm : Form
    {
        private bool _newComer;

        public SetAdminPasswordForm(bool newComer)
        {
            _newComer = newComer;
            InitializeComponent();
            if (newComer)
            {
                NewPasswordBox.Focus();
                MessageBox.Show(
                    "请设置管理员密码，密码需要满足以下要求：\n\n1. 长度至少 8 位\n2. 包含至少一个大写字母\n3. 包含至少一个小写字母\n4. 包含至少一个数字\n5. 包含至少一个特殊字符。",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                OldPasswordBox.Enabled = true;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ValidatePassword())
            {
                var result = Shared.Database.UpdateAdminPassword(
                    NewPasswordBox.Text.ComputeMd5(),
                    _newComer ? null : OldPasswordBox.Text.ComputeMd5()
                );
                if (result)
                {
                    MessageBox.Show(
                        "密码修改成功",
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "密码修改失败，原密码不匹配。",
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private bool ValidatePassword()
        {
#if DEBUG
            if (NewPasswordBox.Text == "gbc")
                return true;
#endif
            if (NewPasswordBox.Text != RepeatPasswordBox.Text)
            {
                MessageBox.Show("两次输入的密码不一致", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NewPasswordBox.Text.Length < 8)
            {
                MessageBox.Show("密码长度必须大于等于 8", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NewPasswordBox.Text.Any(char.IsUpper) == false)
            {
                MessageBox.Show("密码必须包含至少一个大写字母", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NewPasswordBox.Text.Any(char.IsLower) == false)
            {
                MessageBox.Show("密码必须包含至少一个小写字母", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NewPasswordBox.Text.Any(char.IsDigit) == false)
            {
                MessageBox.Show("密码必须包含至少一个数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (NewPasswordBox.Text.Any(char.IsPunctuation) == false)
            {
                MessageBox.Show("密码必须包含至少一个特殊字符", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void NewPasswordBox_Validating(object sender, CancelEventArgs e)
        {
#if DEBUG
            if (NewPasswordBox.Text == "gbc")
            {
                errorProvider1.SetError(NewPasswordBox, null);
                return;
            }
#endif
            StringBuilder sb = new StringBuilder();
            if (NewPasswordBox.Text.Length < 8)
            {
                sb.AppendLine("密码长度必须大于等于 8");
            }
            if (NewPasswordBox.Text.Any(char.IsUpper) == false)
            {
                sb.AppendLine("密码必须包含至少一个大写字母");
            }
            if (NewPasswordBox.Text.Any(char.IsLower) == false)
            {
                sb.AppendLine("密码必须包含至少一个小写字母");
            }
            if (NewPasswordBox.Text.Any(char.IsDigit) == false)
            {
                sb.AppendLine("密码必须包含至少一个数字");
            }
            if (NewPasswordBox.Text.Any(char.IsPunctuation) == false)
            {
                sb.AppendLine("密码必须包含至少一个特殊字符");
            }
            if (sb.Length > 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(NewPasswordBox, sb.ToString());
            }
            else
            {
                errorProvider1.SetError(NewPasswordBox, null);
            }
        }

        private void RepeatPasswordBox_Validating(object sender, CancelEventArgs e)
        {
            if (NewPasswordBox.Text != RepeatPasswordBox.Text)
            {
                errorProvider1.SetError(RepeatPasswordBox, "两次输入的密码不一致");
                e.Cancel = true;
            }
        }

        private void OldPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                NewPasswordBox.Focus();
        }

        private void NewPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                RepeatPasswordBox.Focus();
        }

        private void RepeatPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ConfirmButton.PerformClick();
        }
    }
}
