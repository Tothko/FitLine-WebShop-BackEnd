using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Application_Services
{
    public  interface IUserService
    {
        IEnumerable<User> ReadUsers();
        User Create(User User);
        User Delete(int Id);
        User Update(User UserUpdate);
        User FindUserWithID(int Id);

    }
}
