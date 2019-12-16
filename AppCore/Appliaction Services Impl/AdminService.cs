using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class AdminService : IAdminService
    {

        private IAdminRepository AdminRepo;
        public AdminService(IAdminRepository AdminRepository)
        {
            AdminRepo = AdminRepository;
        }
        public Admin Create(Admin Admin)
        {
            return AdminRepo.Create(Admin);
        }

        public Admin Delete(int Id)
        {
            return AdminRepo.Delete(Id);
        }

        public Admin FindAdminWithID(int Id)
        {
            return AdminRepo.FindAdminWithID(Id);
        }

        public IEnumerable<Admin> ReadAdmins()
        {
            return AdminRepo.ReadAdmins();

        }

        public Admin Update(Admin AdminUpdate)
        {
            return AdminRepo.Update(AdminUpdate);
        }
    }
}
