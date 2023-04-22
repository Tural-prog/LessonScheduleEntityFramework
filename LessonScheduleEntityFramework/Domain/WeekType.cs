namespace LessonScheduleEntityFramework.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeekType")]
    public partial class WeekType
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
