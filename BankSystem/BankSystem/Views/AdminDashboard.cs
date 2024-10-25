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
    public partial class AdminDashboard : Form
    {
        private decimal _capitalSum;
        private int _alarmSum;
        private int _userCount;
        public decimal CapitalSum
        {
            get => _capitalSum;
            set
            {
                _capitalSum = value;
                CapticalSumLabel.Text = $"${_capitalSum:N2}";
            }
        }
        public int AlarmSum
        {
            get => _alarmSum;
            set
            {
                _alarmSum = value;
                AlarmSumLabel.Text = value.ToString();
            }
        }
        public int UserCount
        {
            get => _userCount;
            set
            {
                _userCount = value;
                AccountSumLabel.Text = value.ToString();
            }
        }

        public AdminDashboard()
        {
            InitializeComponent();
            Shared.Database.OnAccountCreated += Database_OnAccountSumChange;
            Shared.Database.OnRiskyTransactionRaised += Database_OnRiskyTransactionRaised;
            Shared.Database.OnAccountDeposit += Database_OnAccountDeposit;
            Shared.Database.OnAccountWithdraw += Database_OnAccountWithdraw;
        }

        private void Database_OnAccountWithdraw(decimal amount)
        {
            CapitalSum -= amount;
        }

        private void Database_OnAccountDeposit(decimal amount)
        {
            CapitalSum += amount;
        }

        private void Database_OnRiskyTransactionRaised(
            Transaction transaction,
            decimal toAccountDailyIntake
        )
        {
            AlarmSum++;
            new ApproveTransactionForm(transaction, toAccountDailyIntake).Show();
        }

        private void Database_OnAccountSumChange(Account account)
        {
            var response = Shared.Database.GetAccountCount();
            UserCount = response;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            new SetAdminPasswordForm(true).ShowDialog();
        }

        private void ChangeAdminPasswordButton_Click(object sender, EventArgs e)
        {
            new SetAdminPasswordForm(false).ShowDialog();
        }

        private void StartUserSpaceButton_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
        }

        private void ViewUsersButton_Click(object sender, EventArgs e)
        {
            new AdminAccountListForm().Show();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确定要退出吗？\n\n所有数据仅保存在内存中，退出将会丢失所有数据。", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
