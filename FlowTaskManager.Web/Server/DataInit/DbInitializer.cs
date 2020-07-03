using FlowTaskManager.Web.Server.Models;
using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammingTask = FlowTaskManager.Web.Shared.Models.ProgrammingTask;
using Type = FlowTaskManager.Web.Shared.Models.Type;

namespace FlowTaskManager.Web.Server.DataInit
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User {
                    UserName = "dombimisi",
                    Password = "123abc",
                    FirstName = "Mihaly",
                    LastName = "Dombi",
                    DateOfBirth = new DateTime(1989, 3, 7),
                    Role = Role.Student
                },
                new User
                {
                    UserName = "laszlo123",
                    Password = "123qwe",
                    FirstName = "Laszlo",
                    LastName = "Nagy",
                    DateOfBirth = new DateTime(1986, 6, 2),
                    Role = Role.Mentor
                },
                new User
                {
                    UserName = "kisgeza",
                    Password = "qweabc",
                    FirstName = "Geza",
                    LastName = "Kis",
                    DateOfBirth = new DateTime(1987, 10, 12),
                    Role = Role.Mentor
                }
            };

            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();

            var programmingTasks = new ProgrammingTask[]
            {
                new ProgrammingTask
                {
                    Type = Type.Java,
                    Title = "Palindrom",
                    Content = "Make a palindrom app",
                    Difficulty = Difficulty.Medium,
                    CreatedAt = new DateTime(2020, 6, 22, 15, 22, 32),
                    UpdatedAt = null,
                    UserId = 2,
                },
                new ProgrammingTask
                {
                    Type = Type.Javascript,
                    Title = "Hello World",
                    Content = "Make a Hello World app",
                    Difficulty = Difficulty.Easy,
                    CreatedAt = new DateTime(2020, 6, 23, 16, 41, 12),
                    UpdatedAt = null,
                    UserId = 3,
                },
                new ProgrammingTask
                {
                    Type = Type.Spring,
                    Title = "Bookstore",
                    Content = "Make a Bookstore RESTApi",
                    Difficulty = Difficulty.Hard,
                    CreatedAt = new DateTime(2020, 6, 27, 9, 10, 04),
                    UpdatedAt = null,
                    UserId = 3,
                }
            };

            dbContext.ProgrammingTasks.AddRange(programmingTasks);
            dbContext.SaveChanges();
        }
    }
}
