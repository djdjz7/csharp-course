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
    public partial class InputForm : Form
    {
        private TaskCompletionSource<string> tcs = new();
        public InputForm(string hint, string title)
        {
            InitializeComponent();
            HintLabel.Text = hint;
            TitleLabel.Text = title;
            this.Text = title;
        }

        public new Task<string> ShowDialog()
        {
            base.ShowDialog();
            return tcs.Task;
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ConfirmButton.PerformClick();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            tcs.SetResult(PasswordBox.Text);
            Close();
        }

        private void InputPasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
