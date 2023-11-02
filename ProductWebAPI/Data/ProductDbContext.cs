﻿using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Modals;

namespace ProductWebAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }

   
}
