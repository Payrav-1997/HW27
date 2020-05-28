using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW27.Models;

namespace HW27.Db
{
    
   
      public class DataContext : DbContext
      {
         public DataContext(DbContextOptions options) : base(options)
         {

         }
        public DataContext()
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData
                (
                  new Category { Id=1,Name="Monitor"},

                  new Category { Id=2,Name="HDD"},

                  new Category { Id = 3, Name = "SSD" },

                  new Category { Id = 4, Name = "VGA" },

                  new Category { Id =5, Name = "CPU" }
                );

        }
       



      }
    


}
