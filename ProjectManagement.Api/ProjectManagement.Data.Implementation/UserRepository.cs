using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Data.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}
