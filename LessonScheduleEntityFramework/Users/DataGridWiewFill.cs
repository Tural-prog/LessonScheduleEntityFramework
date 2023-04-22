using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonScheduleEntityFramework.Users
{
    internal class DataGridWiewFill
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("İstifadəçi adı")]
        public string Name { get; set; }
        [DisplayName("İstifadəçi şifrəsi")]
        public string Password { get; set; }
    }
}
