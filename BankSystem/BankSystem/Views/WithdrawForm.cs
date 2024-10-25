using BankSystem.Models;
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
    public partial class WithdrawForm : Form
    {
        private Account _account;
        private decimal _currentSum = 0;
        public decimal CurrentSum
        {
            get => _currentSum;
            set
            {
                _currentSum = value;
                SumLabel.Text = "$" + _currentSum.ToString("N2");
            }
        }
        public WithdrawForm(Account account)
        {
            InitializeComponent();
            _account = account;
        }

        private async void WithdrawForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                CurrentSum = CurrentSum * 10 + (int)(e.KeyChar - '0');
            }
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                CurrentSum = Math.Floor(CurrentSum / 10);
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                var password = await new InputForm("请输入密码", "验证密码").ShowDialog();
                var response = Shared.Database.Withdraw(_account, password.ComputeMd5(), CurrentSum);
                if (!response.Success)
                {
                    MessageBox.Show(response.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("提现成功！", "提现成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
