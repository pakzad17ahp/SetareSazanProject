using SetareSazanProject.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetareSazanProject.Forms
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Enterbutton_Click(object sender, EventArgs e)
        {
            //if (UserNameTextBox.Text == "1" && PasswordTextBox.Text == "1")
            //{
            //    this.Hide();
            //    MainForm main = new MainForm();
            //    main.Show();
            //}

            LoginRepository login = new LoginRepository();
            if (UserNameTextBox.Text == "")
            {
                MessageBox.Show("لطفا نام کاربری را وارد کنید");
                UserNameTextBox.Select();
            }
            else if (PasswordTextBox.Text == "")
            {
                MessageBox.Show("لطفا رمز عبور را وارد کنید");
                PasswordTextBox.Select();
            }
            else
            {
                if (login.LoginCheck(UserNameTextBox.Text, PasswordTextBox.Text) == false)
                {
                    MessageBox.Show("نام کاربری یا رمز عبور به اشتباه واردشده است");
                    UserNameTextBox.Select();
                }
                else
                {
                    this.Hide();
                    MainForm main = new MainForm();
                    main.Show();
                }
            }
        }
    }
}
