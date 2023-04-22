using LessonScheduleEntityFramework.Domain;
using LessonScheduleEntityFramework.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonScheduleEntityFramework.Users
{
    public partial class frmUser : Form
    {
        int selectedid = -1;
        UserDbOperations _userDbOperations;
        User  _users;
        public frmUser(UserDbOperations userDbOperations)
        {
            InitializeComponent();
            _userDbOperations = userDbOperations;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = new Domain.User();
            user.Name = txtName.Text;
            user.Password = txtPassword.Text;
            _userDbOperations.UserInsert(user);

            dgwUser.DataSource = _userDbOperations.GetUser();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dgwUser.DataSource = _userDbOperations.GetUser();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _userDbOperations.DeletUser(selectedid);
            dgwUser.DataSource = _userDbOperations.GetUser();

        }

        private void dgwUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgwUser.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridWiewFill)row;

                _users = _userDbOperations.GetUserById(val.Id);
                txtName.Text = _users.Name;
                txtPassword.Text = _users.Password;
                selectedid = val.Id;
               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_users != null)
            {
                _users.Name = txtName.Text;
                _users.Password = txtPassword.Text;

                _userDbOperations.UpdateUser(_users);
                dgwUser.DataSource = _userDbOperations.GetUser();

            }
        }
    }
}
