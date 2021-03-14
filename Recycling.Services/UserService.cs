#nullable enable
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Recycling.Data;
using Recycling.Models;

namespace Recycling.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserByUsername(string username)
        {
            return _dbContext.Users
                .Include(u=>u.Orders)
                .Include(u=>u.Addresses)
                .FirstOrDefault(u => u.UserName == username);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
        }
    }
}