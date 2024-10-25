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
    public partial class TransactionDetailsForm : Form
    {
        private Account _account;
        public TransactionDetailsForm(Account account)
        {
            _account = account;
            InitializeComponent();
        }

        private async void TransactionDetailsForm_Load(object sender, EventArgs e)
        {
            var password = await new InputForm("请输入密码", "密码验证").ShowDialog();
            var resp = Shared.Database.GetTransactionList(_account, password.ComputeMd5());
            if(resp.Success)
            {
                MainDataGrid.DataSource = resp.Result!;
            }
            else
            {
                MessageBox.Show(resp.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
