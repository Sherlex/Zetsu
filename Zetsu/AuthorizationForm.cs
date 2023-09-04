using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zetsu
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void Entry_Click(object sender, EventArgs e)
        {
            string passwordOk = "admin";
            
            if (loginTextBox.Text == "admin" && passwordTextBox.Text == passwordOk)
            {
                SpyForm spy = new SpyForm();
                spy.Show();
                Hide();
            }
            else
            {
                loginTextBox.Text = "";
                passwordTextBox.Text = "";
                MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        private void HidePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hidePasswordCheckBox.Checked)
            {
                passwordTextBox.UseSystemPasswordChar = true;
            }
            else
                passwordTextBox.UseSystemPasswordChar = false;
        }
    }
}
