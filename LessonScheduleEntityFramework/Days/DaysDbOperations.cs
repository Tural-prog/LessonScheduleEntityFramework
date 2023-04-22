using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using LessonScheduleEntityFramework.Domain;
using System.ComponentModel;
using Day = LessonScheduleEntityFramework.Domain.Day;

namespace LessonScheduleEntityFramework.Days
{
    public class DaysDbOperations
    {
        private bool IsDayDataValid(string name, bool staus)
        {

            if (name == "")
            {
                MessageBox.Show("Please type name.");
                return false;
            }

            else if ((!staus))
            {
                MessageBox.Show("Please type status");
                return false;
            }
            else
            {

                return true;
            }
        }

        internal void DayInsert(Domain.Day day)
        {
            if(IsDayDataValid(day.Name, day.Status))
            {
                using (var context = new Model1())
                {
                    context.Days.Add(day);
                    context.SaveChanges();
                }
            }
           
        }

        internal IEnumerable<DataGridViewFill> GetDays()
        {
            using (var context = new Model1())
            {
                var days = context.Days.Select(c => new DataGridViewFill()
                {
                    Id = c.Id,
                    Name = c.Name,
                    OrderIndex = c.OrderIndex,
                    Status = c.Status

                });
                return days.ToList();
            }

        }

        internal void UpdateDay(Domain.Day day)
        {
            using (var context = new Model1())
            {

                context.Entry(day).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }



        internal void UpdateDay1(Domain.Day day)
        {
            using (var context = new Model1())
            {
                var days = context.Days.FirstOrDefault(c => c.Id == day.Id);
                if (days != null)
                {
                    days.Name = day.Name;
                    days.OrderIndex = day.OrderIndex;
                    days.Status = day.Status;
                    context.SaveChanges();

                }
            }

        }

        internal void DeleteDay(int id)
        {
            using (var context = new Model1())
            {
                var day = context.Days.FirstOrDefault(c => c.Id == id);
                if (day != null)
                {
                    context.Days.Remove(day);
                    context.SaveChanges();
                }

            }
        }

        internal Day GetDayById(int id)
        {
            using (var context = new Model1())
            {
                return context.Days.FirstOrDefault(c => c.Id == id);

            }
        }

    }
}
