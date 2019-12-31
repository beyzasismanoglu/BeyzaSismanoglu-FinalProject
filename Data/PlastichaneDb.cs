using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BeyzaSismanoglu_FinalProject.Data
{
    public class PlastichaneDb :DbContext
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=BeyzaSismanoglu_FinalProject;Trusted_Connection=True";
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public PlastichaneDb() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    RoleName = "General Manager",
                    Username = "msismanoglu",
                    Password = new Service.UserService().hashPassword("123456"),

                }

                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 2,
                    RoleName = "Product Manager",
                    Username = "barbaros",
                    Password = new Service.UserService().hashPassword("321654"),

                }

                );




        }
    }
}
