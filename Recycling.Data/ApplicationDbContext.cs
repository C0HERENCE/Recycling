using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recycling.Models;

namespace Recycling.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<RecycleOrder> RecycleOrders { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRecord> ProductRecords { get; set; }
        
        public DbSet<Address> Address { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(new List<Category>
            {
                new Category { Id = 1, Name = "纸皮类" },
                new Category { Id = 2, Name = "衣物&其他" },
                new Category { Id = 3, Name = "金属类" },
                new Category { Id = 4, Name = "塑料类" },
            });
            builder.Entity<Price>().HasData(new List<Price>
            {
                new Price { Id = 1, CategoryId = 1, Name = "统纸", Desc = "黄纸和花纸混合", Value = 1.2 },
                new Price { Id = 2, CategoryId = 1, Name = "黄纸", Desc = "纯色纸箱，如家电包装箱", Value = 1.4 },
                new Price { Id = 3, CategoryId = 1, Name = "花纸", Desc = "印刷纸箱， 如矿泉水纸箱", Value = 1 },
                new Price { Id = 4, CategoryId = 1, Name = "书纸", Desc = "各类书籍（不包含杂志）", Value = 1 },
                new Price { Id = 5, CategoryId = 1, Name = "报纸", Desc = "各类报纸（不包含画报）", Value = 1.2 },
                new Price { Id = 6, CategoryId = 2, Name = "衣服", Desc = "完好的衣服", Value = 0.3 },
                new Price { Id = 7, CategoryId = 2, Name = "纺织品", Desc = "毛巾，布料等", Value = 0.2 },
                new Price { Id = 8, CategoryId = 3, Name = "铁", Desc = "铁板、铁块", Value = 1.4 },
                new Price { Id = 9, CategoryId = 3, Name = "不锈钢", Desc = "不锈钢制品", Value = 1 },
                new Price { Id = 10, CategoryId = 3, Name = "铜", Desc = "纯铜机纯铜制品", Value = 18 },
                new Price { Id = 11, CategoryId = 3, Name = "铝", Desc = "铝制品，如易拉罐", Value = 6 },
                new Price { Id = 12, CategoryId = 4, Name = "塑料瓶（透明）", Desc = "干净的饮料瓶", Value = 1 },
                new Price { Id = 13, CategoryId = 4, Name = "塑料筐", Desc = "装水果的塑料筐", Value = 0.6 },
                new Price { Id = 14, CategoryId = 4, Name = "泡沫板", Desc = "白色泡沫板", Value = 0.6 },
            });
            builder.Entity<AdminUser>().HasData(new List<AdminUser>{
                new AdminUser
                {
                    Id = 1,
                    Password = "123",
                    Role = 1,
                    Username = "admin"
                },
                new AdminUser
                {
                    Id = 2,
                    Password = "123",
                    Role = 2,
                    Username = "worker"
                }
            });
            builder.Entity<News>().HasData(new List<News>
            {
                new News
                {
                    Id = 1,
                    AuthorId=1,
                    Content = "gggggggg",
                    CreateTime = DateTime.Now,
                    Enabled = true,
                    Title = "旧物是生活的桃花源"
                },
                new News
                {
                    Id = 2,
                    AuthorId=1,
                    Content = "yyyy",
                    CreateTime = DateTime.Now,
                    Enabled = true,
                    Title = "NEW环保 | 当垃圾换个样子回到你眼前"
                },
                new News
                {
                    Id = 3,
                    AuthorId=1,
                    Content = "qqqq",
                    CreateTime = DateTime.Now,
                    Enabled = true,
                    Title = "断舍离：不止扔扔扔那么简单"
                },
            });

            base.OnModelCreating(builder);
        }
    }
}