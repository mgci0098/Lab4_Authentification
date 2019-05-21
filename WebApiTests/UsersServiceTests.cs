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
                         .UseInMemoryDatabase(databaseName: nameof(ValidRegisterShouldCreateANewUser))// "ValidRegisterShouldCreateANewUser")
                         .Options;

            using (var context = new ObiectiveDbContext(options))
            {
            }
    }
}