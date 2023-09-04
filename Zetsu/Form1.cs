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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string specials = "!\"#$%&'()*+,-./:;<=>?@[]^_`{|}~\\";
            string alphabet = string.Empty;
            string password = string.Empty;
            int password_length = lengthTrackBar.Value;
            int level;
            //double strength;
            if (lowercaseCheckBox.Checked == true)
            {
                alphabet += lower;
            }
            if (numbersCheckBox.Checked == true)
            {
                alphabet += digits;
            }
            if (uppercaseCheckBox.Checked == true)
            {
                alphabet += upper;
            }
            if (specialsCheckBox.Checked == true)
            {
                alphabet += specials;
            }
            Random rand = new Random();
            for (int i = 0; i < password_length; i++)
            {
                password += alphabet[rand.Next(alphabet.Length)];
            }
            passwordTextBox.Text = password;
            level = Check.CheckVerOne(password, alphabet);
            strengthLabel.Text = "Уровень стойкости пароля: " + level.ToString();
            string password_strength = Check.CheckVerTwo(password);
            strength2Label.Text = "Уровень стойкости пароля: " + password_strength;
        }

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (!numbersCheckBox.Checked && !lowercaseCheckBox.Checked && !uppercaseCheckBox.Checked && !specialsCheckBox.Checked)
                generateButton.Enabled = false;
            else
                generateButton.Enabled = true;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string specials = "!\"#$%&'()*+,-./:;<=>?@[]^_`{|}~\\";
            bool upper_symbols = false;
            bool lower_symbols = false;
            bool digits_symbols = false;
            bool specials_symbols = false;
            string alphabet = string.Empty;
            foreach (var symbols in password)
            {
                if ((symbols >= 'A') && (symbols <= 'Z'))
                    upper_symbols = true;
                if ((symbols >= 'a') && (symbols <= 'z'))
                    lower_symbols = true;
                if ((symbols >= '0') && (symbols <= '9'))
                    digits_symbols = true;
                if ("!@#$%^&*()_+-='\";:[{]}\\|.>,</?`~".IndexOf(symbols) >= 0)
                    specials_symbols = true;
            }
            if (upper_symbols)
                alphabet += upper;
            if (lower_symbols)
                alphabet += lower;
            if (digits_symbols)
                alphabet += digits;
            if (specials_symbols)
                alphabet += specials;
            int level = Check.CheckVerOne(password, alphabet);
            strengthLabel.Text = "Уровень стойкости пароля: " + level.ToString();
            string password_strength = Check.CheckVerTwo(password);
            strength2Label.Text = "Уровень стойкости пароля: " + password_strength;
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

        private void SpyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text: "Данная функция программы предназначена только для учебных целей!\n\n" +
                "Чтобы остановить запись лога последовательно нажмите кнопку 'Esc' 5 раз.\n" +
                "Лог находится в корневой директории программы.",
             caption: "Внимание!",
             buttons: MessageBoxButtons.OK,
             icon: MessageBoxIcon.Warning);
            AuthorizationForm auth = new AuthorizationForm();
            auth.Show();
            this.Hide();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text: "Данная программа является генератором паролей с возможностью проверки " +
                "их на надежность.\n\n",
             caption: "О программе",
             buttons: MessageBoxButtons.OK,
             icon: MessageBoxIcon.Information);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text: "Для проверки пароля на надежность введите его в поле и нажмите на кнопку \"Check!\".\n\n" +
                "Программа проверяет пароль двумя способами:\n" +
                "1. Без словаря, учитывая только мощность алфавита и длину пароля.\n" +
                "2. Со словарем, учитывая длину пароля, используемые символы и совпадения" +
                " с наиболее распространенными вариантами паролей.",
            caption: "Помощь",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Question);
        }
    }
}
