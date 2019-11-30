using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class UserService : IUserService
    {

        private IUserRepository UserRepo;
        public UserService(IUserRepository UserRepository)
        {
            UserRepo = UserRepository;
        }
        public User Create(User User)
        {
            return UserRepo.Create(User);
        }

        public User Delete(int Id)
        {
            return UserRepo.Delete(Id);
        }

        public User FindUserWithID(int Id)
        {
            return UserRepo.FindUserWithID(Id);
        }

        public IEnumerable<User> ReadUsers()
        {
            return UserRepo.ReadUsers();

        }

        public User Update(User UserUpdate)
        {
            return UserRepo.Update(UserUpdate);
        }
    }
}
