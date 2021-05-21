using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Recycling.Data;
using Recycling.Models;

namespace Recycling.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;

        public OrderService(ApplicationDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public List<RecycleOrder> GetOrdersByUsername(string username)
        {
            return _userService.GetUserByUsername(username)
                ?.Orders.ToList();
        }

        public void AddOrder(string username, RecycleOrder order)
        {
            _userService.GetUserByUsername(username)?.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public RecycleOrder GetOrderById(int id)
        {
            return _dbContext.RecycleOrders
                .Include(o => o.Address)
                .Include(o => o.RecycleItems)
                    .ThenInclude(re => re.Category)
                .FirstOrDefault(o => o.Id == id);
        }

        public void CancelOrder(int currentOrderId)
        {
            var order = _dbContext.RecycleOrders.FirstOrDefault(o => o.Id == currentOrderId);
            if (order == null) return;
            order.OrderStatus = OrderStatus.Canceled;
            _dbContext.SaveChanges();
        }
    }
}