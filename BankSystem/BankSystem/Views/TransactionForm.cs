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
    public partial class TransactionForm : Form
    {
        private Account _account;
        private decimal _currentSum = 0;
        private Transaction? _transaction;
        public decimal CurrentSum
        {
            get => _currentSum;
            set
            {
                _currentSum = value;
                SumLabel.Text = "$" + _currentSum.ToString("N2");
            }
        }
        public TransactionForm(Account account)
        {
            InitializeComponent();
            _account = account;
        }

        private async void TransactionForm_KeyPress(object sender, KeyPressEventArgs e)
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
                var destAccLoginName = await new InputForm("请输入收款账户登录名", "转账").ShowDialog();
                if(destAccLoginName == _account.LoginName)
                {
                    MessageBox.Show("不能转账给自己！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var destAccResp = Shared.Database.GetAccount(destAccLoginName);
                if (!destAccResp.Success)
                {
                    MessageBox.Show(destAccResp.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var msgboxResult = MessageBox.Show("确认转账 $" + CurrentSum.ToString("N2") + " 到 " + destAccResp.Result!.Name + " 吗？", "确认转账", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgboxResult!= DialogResult.Yes)
                return; 

                var password = await new InputForm("请输入密码", "验证密码").ShowDialog();
                var response = Shared.Database.Transact(_account, destAccResp.Result!, password.ComputeMd5(), CurrentSum);
                if (!response.Success)
                {
                    MessageBox.Show(response.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (response.Message!.Contains("审核"))
                    {
                        this.KeyPress -= TransactionForm_KeyPress!;
                        CancelButton.Enabled = false;
                        HintLabel.Visible = false;
                        TitleLabel.Text = $"转账至 {destAccResp.Result!.Name}\n正等待管理员批准...";

                        _transaction = response.Result!;
                        Shared.Database.OnRiskyTransactionApproved += OnRiskyTransactionApproved;
                        Shared.Database.OnRiskyTransactionDenied += OnRiskyTransactionDenied;
                    }
                    return;
                }
                MessageBox.Show("转账成功！", "转账成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void OnRiskyTransactionDenied(Transaction transaction)
        {
            if (transaction.TransactionId == _transaction!.TransactionId)
            {
                MessageBox.Show("管理员已拒绝此转账。", "转账失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void OnRiskyTransactionApproved(Transaction transaction)
        {
            if(transaction.TransactionId == _transaction!.TransactionId)
            {
                MessageBox.Show("管理员已批准此转账。", "转账成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
