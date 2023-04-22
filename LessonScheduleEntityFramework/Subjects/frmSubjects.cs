using LessonScheduleEntityFramework.Days;
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

namespace LessonScheduleEntityFramework.Subjects
{
    public partial class frmSubjects : Form
    {
        int selectedid = -1;
        SubjectsDbOperation _subjectDbOperations;
        Subject _subjects;
        public frmSubjects(SubjectsDbOperation subjectDbOperations)
        {
            InitializeComponent();
            _subjectDbOperations = subjectDbOperations;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var subject =new Domain.Subject();
            subject.Status = chckStatus.Checked;
            subject.Decription = txtDecription.Text;
            subject.Name =txtName.Text;
            subject.OrderIndex = (int)numUpDownSubject.Value;
            _subjectDbOperations.SubjectInsert(subject);

            dgwSubjects.DataSource = _subjectDbOperations.GetSubjects();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgwSubjects.DataSource = _subjectDbOperations.GetSubjects();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _subjectDbOperations.DeletSubject(selectedid);
            dgwSubjects.DataSource = _subjectDbOperations.GetSubjects();

        }

        private void dgwSubjects_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgwSubjects.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridViewFill)row;

                _subjects = _subjectDbOperations.GetSubjectById(val.Id);
                txtName.Text = _subjects.Name;
                txtDecription.Text = _subjects.Decription;
                chckStatus.Checked = _subjects.Status;
                selectedid = val.Id;
                numUpDownSubject.Value = _subjects.OrderIndex;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_subjects !=null)
            {
                _subjects .Status = chckStatus.Checked;
                _subjects .OrderIndex = (int)numUpDownSubject.Value;
               _subjects.Name = txtName.Text;
               _subjects.Decription = txtDecription.Text;

                _subjectDbOperations.UpdateSubject(_subjects);
                dgwSubjects.DataSource = _subjectDbOperations.GetSubjects();

            }
        }
    }
}
