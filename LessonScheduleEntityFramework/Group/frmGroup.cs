using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonScheduleEntityFramework.Group
{
    public partial class frmGroup : Form
    {
        int selectedid = -1;
        GroupDbOperation _groupDbOperation;
         
        public frmGroup()
        {
            InitializeComponent();
        }

       
    }
}
