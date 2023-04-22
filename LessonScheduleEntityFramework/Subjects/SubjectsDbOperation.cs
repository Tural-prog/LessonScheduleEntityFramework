using LessonScheduleEntityFramework.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LessonScheduleEntityFramework.Subjects
{
    public class SubjectsDbOperation
    {
        internal bool IsSubjectDataValid(string Name, string Decription, bool Staus)
        {

            if (Name == "")
            {
                MessageBox.Show("Please type name.");
                return false;
            }
            else if ((!Staus))
            {
                MessageBox.Show("Please type status");
                return false;
            }
            else if (Decription == " ")
            {
                MessageBox.Show("Please type decription");
                return false;
            }

            else
            {
                return true;
            }
        }
        internal void SubjectInsert (Domain.Subject subject)
        {
            if (IsSubjectDataValid(subject.Name, subject.Decription, subject.Status))
            {
                using (var context = new Model1())
                {
                    context.Subjects.Add(subject);
                    context.SaveChanges();
                }
            }        
            
        }
        internal IEnumerable<DataGridViewFill> GetSubjects()
        {
            using(var context =new Model1())
            {
                var subjects = context.Subjects.Select(c => new DataGridViewFill()
                {
                    Id=c.Id,
                    Name =c.Name,
                    Status = c.Status,
                    OrderIndex = c.OrderIndex,
                    Decription= c.Decription,
                });
                return subjects.ToList();
            }
        }
        internal void UpdateSubject(Domain.Subject subject)
        {
            using (var context =new Model1())
            {
                context.Entry(subject) .State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges ();
            }
        }
        internal void DeletSubject (int id)
        {
            using (var context = new Model1 ())
            {
                var subject =context.Subjects.FirstOrDefault(c => c.Id == id);
                if(subject != null)
                {
                    context.Subjects.Remove(subject);
                    context.SaveChanges ();
                }
            }

        } 
        internal Subject GetSubjectById(int id)
        {
            using (var context = new Model1())
            {
                return context.Subjects.FirstOrDefault (c => c.Id == id);
            }
        }
       
    }
}
