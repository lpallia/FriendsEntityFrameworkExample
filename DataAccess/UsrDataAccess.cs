using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess
{
    public class UsrDataAccess : IDataAccess<User>
    {
        public void Add(User entity)
        {
            using (FriendContext context = new FriendContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (FriendContext context = new FriendContext())
            {
                context.Users.Remove(entity);
            }
        }

        public User Get(Guid id)
        {
            using (FriendContext context = new FriendContext())
            {
                User user = context.Users.FirstOrDefault(a => a.Id == id);
                context.Entry(user).Collection(a => a.Agendas).Load();
                //context.Entry(user).Collection(a => a.Contacts).Load(); 
                return user;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (FriendContext context = new FriendContext())
            {
                return context.Users;
            }
        }

        public void Modify(User entity)
        {
            using (FriendContext context = new FriendContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                //context.Entry(entity.Owner).State = EntityState.Modified;

                foreach (var agenda in entity.Agendas)
                {
                    context.Entry(agenda).State = agenda.Id.Equals(Guid.Empty) ? EntityState.Added : EntityState.Unchanged;
                }

                context.SaveChanges();
            }
        }
    }
}
