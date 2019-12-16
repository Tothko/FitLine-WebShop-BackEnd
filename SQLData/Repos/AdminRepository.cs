using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class AdminRepository : IAdminRepository
    {
        

        readonly FitLineContext context;

        public AdminRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Admin Create(Admin Admin)
        {
            context.Admins.Add(Admin);
            context.SaveChanges();
            return context.Admins.Find(Admin.ID);
        }

        public Admin Delete(int Id)
        {
            context.Admins.Remove(FindAdminWithID(Id));
            context.SaveChanges();
            return null;
        }

        public Admin FindAdminWithID(int Id)
        {
            return context.Admins.FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<Admin> ReadAdmins()
        {
            return context.Admins;
        }

        public Admin Update(Admin AdminUpdate)
        {
            context.Attach(AdminUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.Admins.Find(FindAdminWithID(AdminUpdate.ID));
        }
    }
    }

