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
    public partial class AdminAccountListForm : Form
    {
        public AdminAccountListForm()
        {
            InitializeComponent();
        }

        private async void AdminUserListForm_Load(object sender, EventArgs e)
        {
            var password = await new InputForm("请输入管理员密码", "密码验证").ShowDialog();
            var response = Shared.Database.GetAccountList(password.ComputeMd5());
            if(!response.Success)
            {
                MessageBox.Show(response.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            MainDataGrid.DataSource = response.Result;
        }
    }
}
