using BankSystem.Models;

namespace BankSystem.Views
{
    public partial class ApproveTransactionForm : Form
    {
        private Transaction _transaction { get; set; }
        public ApproveTransactionForm(Transaction transaction, decimal toAccountDailyIntake)
        {
            _transaction = transaction;
            InitializeComponent();
            FromAccountDetails.Text =
                $"姓名: {transaction.FromAccount!.Name}\n登录名: {transaction.FromAccount.LoginName}\nAccount ID: {transaction.FromAccount.AccountId}\n转账时间: {transaction.TransactionTime}";
            ToAccountDetails.Text =
                $"姓名: {transaction.ToAccount!.Name}\n登录名: {transaction.ToAccount.LoginName}\nAccount ID: {transaction.ToAccount.AccountId}\n本日进账: ${toAccountDailyIntake:N2}";
            AmountLabel.Text = $"${transaction.Amount:N2}";
        }

        private async void ApproveButton_Click(object sender, EventArgs e) {
            var password = await new InputForm("请输入管理员密码", "密码验证").ShowDialog();
            var response = Shared.Database.ApproveRiskyTransaction(_transaction, password.ComputeMd5());
            if (response.Success)
                Close();
            else 
                MessageBox.Show(response.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void DenyButton_Click(object sender, EventArgs e)
        {
            var password = await new InputForm("请输入管理员密码", "密码验证").ShowDialog();
            var response = Shared.Database.DenyRiskyTransaction(_transaction, password.ComputeMd5());
            if (response.Success)
                Close();
            else
                MessageBox.Show(response.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ApproveTransactionForm_Load(object sender, EventArgs e) { }
    }
}
