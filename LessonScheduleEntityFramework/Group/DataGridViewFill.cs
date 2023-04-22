using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonScheduleEntityFramework.Group
{
    internal class DataGridViewFill
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Gurupun Adı")]
        public string Name { get; set; }
        [DisplayName("Gurupun Statusu")]
        public bool Status { get; set; }
    }
}
