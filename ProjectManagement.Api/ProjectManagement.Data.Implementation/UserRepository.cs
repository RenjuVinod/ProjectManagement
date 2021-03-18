using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Data.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ProjectManagementContext _context;

        public UserRepository(ProjectManagementContext context): base(context)
        {
            _context = context;
        }

        public User Login(User user)
        {
            return _context.User.Where(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password)).FirstOrDefault();
        }
    }
}
