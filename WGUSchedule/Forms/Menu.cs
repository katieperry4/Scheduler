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
    public partial class Menu : Form
    {
        private MenuPresenter _menuPresenter;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Clock.Text = _menuPresenter.getTime();
        }

        public void setPresenter(MenuPresenter menuPresenter)
        {
            _menuPresenter = menuPresenter;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CustomersButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.redirect("customer");
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.redirect("calendar");
        }

        private void AppointmentsButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.redirect("appointments");
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            _menuPresenter.redirect("reports");
        }
    }
}
