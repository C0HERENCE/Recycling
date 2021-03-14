using System;
using System.Collections.Generic;
using System.Linq;
using Recycling.Data;
using Recycling.Models;

namespace Recycling.Services
{
    public class AddressService
    {
        
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;

        public AddressService(ApplicationDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public List<Address> GetAddressByUsername(string username)
        {
            return _userService.GetUserByUsername(username)?
                .Addresses.Where(a => a.Enabled).ToList();
        }

        public void AddAddressToUser(string username, Address address)
        {
            _userService.GetUserByUsername(username)
                ?.Addresses.Add(address);
            _dbContext.SaveChanges();
        }

        public int? GetAddressCountByUsername(string username)
        {
            return _userService.GetUserByUsername(username)
                ?.Addresses.Count(a => a.Enabled);
        }
    }
}