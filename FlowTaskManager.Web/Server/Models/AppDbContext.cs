using FlowTaskManager.Web.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = FlowTaskManager.Web.Shared.Models.Type;

namespace FlowTaskManager.Web.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Creating User records
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "dombimisi",
                Password = "123abc",
                FirstName = "Mihaly",
                LastName = "Dombi",
                DateOfBirth = new DateTime(1989, 3, 7),
                Role = Role.Student
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "laszlo123",
                Password = "123qwe",
                FirstName = "Laszlo",
                LastName = "Nagy",
                DateOfBirth = new DateTime(1986, 6, 2),
                Role = Role.Mentor
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                UserName = "kisgeza",
                Password = "qweabc",
                FirstName = "Geza",
                LastName = "Kis",
                DateOfBirth = new DateTime(1987, 10, 12),
                Role = Role.Mentor
            });

            // Creating Task records
            modelBuilder.Entity<Task>().HasData(new Task
            {
                Id = 1,
                Type = Type.Java,
                Title = "Palindrom",
                Content = "Make a palindrom app",
                Difficulty = Difficulty.Medium,
                CreatedAt = new DateTime(2020, 6, 22, 15, 22, 32),
                UpdatedAt = null,
                UserId = 2
            });

            modelBuilder.Entity<Task>().HasData(new Task
            {
                Id = 2,
                Type = Type.Javascript,
                Title = "Hello World",
                Content = "Make a Hello World app",
                Difficulty = Difficulty.Easy,
                CreatedAt = new DateTime(2020, 6, 23, 16, 41, 12),
                UpdatedAt = null,
                UserId = 3
            });

            modelBuilder.Entity<Task>().HasData(new Task
            {
                Id = 3,
                Type = Type.Spring,
                Title = "Bookstore",
                Content = "Make a Bookstore RESTApi",
                Difficulty = Difficulty.Hard,
                CreatedAt = new DateTime(2020, 6, 27, 9, 10, 04),
                UpdatedAt = null,
                UserId = 3
            });
        }
    }
}
