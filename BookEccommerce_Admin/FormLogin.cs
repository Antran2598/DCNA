using BookEccommerce_Admin.Models;
using BussinessLogicLayer_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookEccommerce_Admin
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Account account = new Account()
            {
                Username = txt_username.Text,
                Password = txt_password.Text,
            };

            bool result = new AccountManagement().checkLogin(account.Username, account.Password);
            if (result == true)
            {
                MessageBox.Show(this, "Login successfully, it's moving to Admin Form");
                this.Hide();
                FrmDashboard frmAdmin = new FrmDashboard();
                frmAdmin.Show();
            }
            else
                MessageBox.Show(this, "Login uncessfully, please check it again");
        }
    }
    }

