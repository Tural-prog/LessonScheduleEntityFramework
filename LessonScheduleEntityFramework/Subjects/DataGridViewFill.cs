using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonScheduleEntityFramework.Subjects
{
    internal class DataGridViewFill
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Fənnin adı")]
        public string Name { get; set; }
        [DisplayName("Fənnin təsviri")]
        public string Decription { get; set; }
        [DisplayName("Statusu")]
        public bool Status { get; set; }
        [DisplayName("Sıralama")]
        public int OrderIndex { get; set; }

       
    }
}
