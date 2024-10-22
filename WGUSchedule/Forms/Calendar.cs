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
    public partial class Calendar : Form
    {
        private CalendarPresenter _calendarPresenter;
        private int _userId;

        public Calendar()
        {
            InitializeComponent();
        }

        public void setPresenter(CalendarPresenter calendarPresenter, int userId)
        {
            _calendarPresenter = calendarPresenter;
            _userId = userId;
        }

        private void Calendar_Load(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _calendarPresenter.cancel();
        }
    }
}
