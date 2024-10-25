using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankSystem.Models;

namespace BankSystem.Views
{
    public partial class UserDashboard : Form
    {
        private Account _account;
        private decimal _currentBalance = 0;
        public decimal CurrentBalance
        {
            get => _currentBalance;
            set
            {
                _currentBalance = value;
                BalanceLabel.Text = $"${_currentBalance:N2}";
            }
        }

        public UserDashboard(Account account)
        {
            _account = account;
            InitializeComponent();
            WelcomeBackLabel.Text = $"欢迎回来，{account.Name} {account.Pronouns}";
            Shared.Database.OnTransactionCompleted += Database_OnTransactionCompleted;
        }

        private void Database_OnTransactionCompleted(Transaction transaction)
        {
            if (transaction.FromAccount == _account || transaction.ToAccount == _account)
                UpdateBalance();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            UpdateBalance();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartTransactionButton_Click(object sender, EventArgs e)
        {
            new TransactionForm(_account).Show();
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            new DepositForm(_account).Show();
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            new WithdrawForm(_account).Show();
        }

        private void BalanceDetailsButton_Click(object sender, EventArgs e)
        {
            new TransactionDetailsForm(_account).Show();
        }

        private void UpdateBalance()
        {
            var response = Shared.Database.GetBalance(_account);
            if (response.Success)
            {
                CurrentBalance = response.Result;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
            var gtresp = Shared.Database.GetLastTransaction(_account);
            if (gtresp.Success)
            {
                if (gtresp.Result != null)
                {
                    LastTransactionLabel.Text =
                        $"最后纪录: {(gtresp.Result.FromAccount == _account ? "-" : "+")}${gtresp.Result.Amount:N2}\n{gtresp.Result.TransactionTime}";
                }
                else
                    LastTransactionLabel.Text = "未查询到最近一次转账记录。";
            }
            else
            {
                MessageBox.Show(gtresp.Message);
            }
        }
    }
}
