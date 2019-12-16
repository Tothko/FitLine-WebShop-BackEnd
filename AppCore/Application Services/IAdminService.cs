using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Application_Services
{
    public  interface IAdminService
    {
        IEnumerable<Admin> ReadAdmins();
        Admin Create(Admin Admin);
        Admin Delete(int Id);
        Admin Update(Admin AdminUpdate);
        Admin FindAdminWithID(int Id);

    }
}
