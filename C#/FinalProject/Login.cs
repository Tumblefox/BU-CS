using System;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Login : Form
    {
        MySQLHandler handler;

        public Login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string sql = "select count('username') from admins where username='" + user_box.Text + "' and password='" + pass_box.Text + "'";

            //Verify user creditials agains the database
            handler = new MySQLHandler();
            handler.Login(sql);

            //Open New Windows, close this one
            //TODO: Closing this Login window closes all windows created by it
            CustomerMaintenance maintenance = new CustomerMaintenance();
            maintenance.Show();
            //Hide();
        }
    }
}
