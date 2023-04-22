using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonScheduleEntityFramework.Days
{
    internal class DataGridViewFill
    {


        [DisplayName("Adı")]
        public string Name { get; set; }
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Statusu")]
        public bool Status { get; set; }
        public int OrderIndex { get; set; }
    }
}
