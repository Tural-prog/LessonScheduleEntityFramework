using LessonScheduleEntityFramework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Day = LessonScheduleEntityFramework.Domain.Day;

namespace LessonScheduleEntityFramework.Days
{
    public partial class frmDays : Form
    {
        int selectedid = -1;
        DaysDbOperations _daysDbOperations;
        Day _day;
        public frmDays(DaysDbOperations daysDbOperations)
        {
            InitializeComponent();
            _daysDbOperations = daysDbOperations;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgwDays.DataSource = _daysDbOperations.GetDays();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var day = new Domain.Day();
            day.Status = chckStatus.Checked;
            day.Name = txtName.Text;
            day.OrderIndex = (int)numUpDownDays.Value;

            _daysDbOperations.DayInsert(day);
            dgwDays.DataSource = _daysDbOperations.GetDays();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            _daysDbOperations.DeleteDay(selectedid);
            dgwDays.DataSource = _daysDbOperations.GetDays();
        }

        private void dgwDays_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgwDays.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridViewFill)row;

                _day = _daysDbOperations.GetDayById(val.Id);
                txtName.Text = _day.Name;
                chckStatus.Checked = _day.Status;
                selectedid = val.Id;
                numUpDownDays.Value = _day.OrderIndex;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_day == null) { MessageBox.Show("Please choose the day"); }
            _day.Status = chckStatus.Checked;
            _day.Name = txtName.Text;
            _day.OrderIndex = (int)numUpDownDays.Value;

            _daysDbOperations.UpdateDay1(_day);
            dgwDays.DataSource = _daysDbOperations.GetDays();

        }
    }
}
