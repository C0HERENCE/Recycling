using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Recycling.Data;
using Recycling.Models;

namespace Recycling.Services
{
    public class ProductRecordService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;

        private ProductRecordService(ApplicationDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public List<ProductRecord> GetAll()
        {
            return _dbContext.ProductRecords.ToList();
        }

        public List<ProductRecord> GetProductRecordsByUserId(int userId)
        {
            return _dbContext.ProductRecords
                .Include(o => o.User)
                .Include(o => o.Product)
                .Where(o => o.UserId == userId).ToList();
        }

        public void AddProductRecord(int userId, int productId)
        {
            ProductRecord productRecord = new ProductRecord();
            productRecord.UserId = userId;
            productRecord.ProductId = productId;
            productRecord.CreateDateTime = DateTime.Now;
            _dbContext.ProductRecords.Add(productRecord);
            _dbContext.SaveChanges();
        }
    }
}