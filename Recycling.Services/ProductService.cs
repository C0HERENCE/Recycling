using System.Collections.Generic;
using System.Linq;
using Recycling.Data;
using Recycling.Models;

namespace Recycling.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _dbContext;


        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.Where(p=>p.Enabled).ToList();
        }
    }
}