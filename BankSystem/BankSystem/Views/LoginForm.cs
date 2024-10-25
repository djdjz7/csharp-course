using BankSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            new SignupForm().Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var response = Shared.Database.Login(LoginNameBox.Text, PasswordBox.Text.ComputeMd5());
            if (response.Success)
            {
                LoginNameBox.Clear();
                PasswordBox.Clear();
                LoginNameBox.Focus();

                new UserDashboard(response.Result!).Show();
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void LoginNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                PasswordBox.Focus();
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LoginButton.PerformClick();
        }
    }
}
