using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUSchedule.Presenters;

namespace WGUSchedule.Forms
{
    public partial class Login : Form
    {
        private LoginPresenter _loginPresenter;
        public Login()
        {
            InitializeComponent();
        }

        public void setPresenter(LoginPresenter loginPresenter)
        {
            _loginPresenter = loginPresenter;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string lg = _loginPresenter.getCulture();
            string location = _loginPresenter.getLocation();
            LocationEdit.Text = location;
            if (lg == "fr")
            {
                UsernameLabel.Text = "Nom d'utilisateur";
                PasswordLabel.Text = "Mot de Passe";
                LoginButton.Text = "Se Connecter";
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string userName = UsernameBox.Text;
            string password = PasswordBox.Text;
            try
            {

                bool validlogin = _loginPresenter.login(userName, password);
                _loginPresenter.logLogin(userName, validlogin);
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }

        }

       
    }
}
