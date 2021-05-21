#nullable enable
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Recycling.Data;
using Recycling.Models;

namespace Recycling.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category? GetCategoryByName(string categoryName)
        {
            return _dbContext.Categories.Include(c => c.Prices).FirstOrDefault(c => c.Name == categoryName);
        }

        public List<Price>? GetPriceByCategoryName(string categoryName)
        {
            return GetCategoryByName(categoryName)?.Prices.Where(x=>x.Enabled).ToList();
        }
    }
}