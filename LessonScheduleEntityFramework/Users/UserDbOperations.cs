using LessonScheduleEntityFramework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonScheduleEntityFramework.Users
{
    public class UserDbOperations
    {
        internal bool IsUserDataValid(string Name, string Password )
        {

            if (Name == "")
            {
                MessageBox.Show("Please type name.");
                return false;
            }
           
            else if (Password == " ")
            {
                MessageBox.Show("Please type password");
                return false;
            }

            else
            {
                return true;
            }
        }
        internal void UserInsert(Domain.User user)
        {
            if (IsUserDataValid(user.Name, user.Password))
            {
                using (var context = new Model1())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }

        }
        internal IEnumerable<DataGridWiewFill> GetUser()
        {
            using (var context = new Model1())
            {
                var users = context.Users.Select(c => new DataGridWiewFill()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Password = c.Password,
                });
                return users.ToList();
            }
        }
        internal void UpdateUser(Domain.User user)
        {
            using (var context = new Model1())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        internal void DeletUser(int id)
        {
            using (var context = new Model1())
            {
                var user = context.Users.FirstOrDefault(c => c.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }

        }
        internal User GetUserById(int id)
        {
            using (var context = new Model1())
            {
                return context.Users.FirstOrDefault(c => c.Id == id);
            }
        }

    }
}
