namespace LessonScheduleEntityFramework.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subject
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public bool Status { get; set; }

        [StringLength(500)]
        public string Decription { get; set; }

        public int OrderIndex { get; set; }
    }
}
