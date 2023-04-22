using LessonScheduleEntityFramework.Days;
using LessonScheduleEntityFramework.Subjects;
using LessonScheduleEntityFramework.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonScheduleEntityFramework
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void daysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmDays = new frmDays(new DaysDbOperations());
            frmDays.ShowDialog();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmSubject = new frmSubjects( new SubjectsDbOperation());
            frmSubject.Show();


        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmUser = new frmUser(new UserDbOperations());
            frmUser.ShowDialog();

        }
    }
}
