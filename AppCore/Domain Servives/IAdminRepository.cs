using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> ReadAdmins();
        Admin Create(Admin Admin);
        Admin Delete(int Id);
        Admin Update(Admin AdminUpdate);
        Admin FindAdminWithID(int Id);
    }
}
