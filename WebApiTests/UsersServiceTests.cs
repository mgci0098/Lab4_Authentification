using Lab3.Services;
using Laborator2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Tests
{
    public class UsersServiceTests

    {
        private IOptions<AppSettings> config;

        [SetUp]
        public void Setup()
        {
            config = Options.Create(new AppSettings
            {
                //trebuie sa fie suficient de lunga.
                Secret = "dsadhjcghduihdfhdifd8ih"
            });
        }

        /// <summary>
        /// TODO: AAA - Arrange, Act, Assert
        /// </summary>
        [Test]
        public void ValidRegisterShouldCreateNewUser()
        {
            var options = new DbContextOptionsBuilder<ObiectiveDbContext>()
                         .UseInMemoryDatabase(databaseName: nameof(ValidRegisterShouldCreateNewUser))// "ValidRegisterShouldCreateANewUser")
                         .Options;

            using (var context = new ObiectiveDbContext(options))
            {
                var usersService = new UsersService(context, config);
                var added = new Lab3.ViewModels.RegisterPostModel
                {
                    Email = "em1@y.com",
                    FirstName = "firstName1",
                    LastName = "lastName1",
                    UserName = "test_userName1",
                    Password = "987654"
                };

                var result = usersService.Register(added);

                Assert.IsNotNull(result);
                Assert.AreEqual(added.UserName, result.UserName);
            }
        }
    }
}