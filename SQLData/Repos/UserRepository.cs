using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class UserRepository : IUserRepository
    {
        

        readonly FitLineContext context;

        public UserRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public User Create(User User)
        {
            context.Users.Add(User);
            context.SaveChanges();
            return context.Users.Find(User.ID);
        }

        public User Delete(int Id)
        {
            context.Users.Remove(FindUserWithID(Id));
            context.SaveChanges();
            return null;
        }

        public User FindUserWithID(int Id)
        {
            return context.Users
                .AsNoTracking()
                .Include(p => p.Addresses)
                .Include(p => p.Orders)
                .FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<User> ReadUsers()
        {
            return context.Users
                .AsNoTracking()
                .Include(p => p.Addresses)
                .Include(p => p.Orders);
        }

        public User Update(User UserUpdate)
        {
            context.Attach(UserUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.Users.Find(FindUserWithID(UserUpdate.ID));
        }
    }
    }

