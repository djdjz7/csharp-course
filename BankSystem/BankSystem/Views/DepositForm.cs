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
    public partial class DepositForm : Form
    {
        private Account _account;
        public DepositForm(Account account)
        {
            InitializeComponent();
            _account = account;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var response = Shared.Database.Deposit(_account, 5000);
            if (response.Success)
            {
                MessageBox.Show("存入成功！");
                Close();
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
