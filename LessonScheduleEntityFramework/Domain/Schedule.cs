namespace LessonScheduleEntityFramework.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Schedule
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int DayId { get; set; }

        public int SubjectId { get; set; }

        public int UsersId { get; set; }

        public int OrderIndex { get; set; }

        public int? WeekTypeId { get; set; }
    }
}
