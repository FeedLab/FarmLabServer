using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using FarmLabService;
using FarmLabService.Dal;
using FarmLabService.DataObjects;
using FarmLabService.Services;
using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private FarmLabContext _farmLabContext;

        [SetUp]
        public void Setup()
        {
            var args = new List<string>();

            var webHost = WebHost.CreateDefaultBuilder(args.ToArray())
                .UseStartup<Startup>()
                .Build();

            _farmLabContext = webHost.Services.GetService<FarmLabContext>();

        }

        [Test]
        public async Task SessionItem_WhenUserExists_ThenAssociateUserWithANewSession()
        {
            // Arrange
            var userRepository = new UserRepository(_farmLabContext);
            var email = $"Billy@gates.com_{Guid.NewGuid()}";

            var user = new UserItem
            {
                DisplayName = "Billy",
                Email = email,
                Farm = null,
                FirstName = "None",
                IsConfirmedByMail = false,
                IsEnabled = false,
                LastName = "Gates",
                Password = "123",
                RoleType = RoleType.FarmCreator,
                TimeCreate = DateTime.UtcNow,
                TimeModify = DateTime.UtcNow
            };

            var userInDatabase = new UserItem
            {
                DisplayName = "Billy",
                Email = email,
                Farm = null,
                FirstName = "None",
                IsConfirmedByMail = false,
                IsEnabled = false,
                LastName = "Gates",
                Password = "123",
                RoleType = RoleType.FarmCreator,
                TimeCreate = DateTime.UtcNow,
                TimeModify = DateTime.UtcNow
            };

            await _farmLabContext.User.AddAsync(userInDatabase);
            await _farmLabContext.SaveChangesAsync();

            // Act
            var sessionItem = await userRepository.CreateSessionAndAssociateUserAsync(user);

            // Assert
            sessionItem.User.Email.Should().Be(user.Email);
            sessionItem.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task SessionItem_WhenUserNotExists_ThenCreateUserAndAssociateWithANewSession()
        {
            // Arrange
            var userRepository = new UserRepository(_farmLabContext);
            var email = $"Billy@gates.com_{Guid.NewGuid()}";

            var user = new UserItem
            {
                DisplayName = "Billy",
                Email = email,
                Farm = null,
                FirstName = "None",
                IsConfirmedByMail = false,
                IsEnabled = false,
                LastName = "Gates",
                Password = "123",
                RoleType = RoleType.FarmCreator,
                TimeCreate = DateTime.UtcNow,
                TimeModify = DateTime.UtcNow
            };

            // Act
            var sessionItem = await userRepository.CreateSessionAndAssociateUserAsync(user);

            // Assert
            sessionItem.User.Email.Should().Be(user.Email);
            sessionItem.Id.Should().BeGreaterThan(0);
        }

        #region UserItem

        [Test]
        public async Task UserItem_WhenNewUserIsAdded_ThenNewUserIsReturned()
        {
            // Arrange
            var userRepository = new UserRepository(_farmLabContext);

            var user = new UserItem
            {
                DisplayName = "Billy",
                Email = $"Billy@gates.com_{Guid.NewGuid()}",
                Farm = null,
                FirstName = "None",
                IsConfirmedByMail = false,
                IsEnabled = false,
                LastName = "Gates",
                Password = "123",
                RoleType = RoleType.FarmCreator,
                TimeCreate = DateTime.UtcNow,
                TimeModify = DateTime.UtcNow
            };

            // Act
            var userItem = await userRepository.GetUserAsync(user);

            // Assert
            userItem.Email.Should().Be(user.Email);
            userItem.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task UserItem_WhenExistenUserIsAdded_ThenUserIsReturned()
        {
            // Arrange
            var userRepository = new UserRepository(_farmLabContext);
            var email = $"Billy@gates.com_{Guid.NewGuid()}";

            var userInDatabase = new UserItem
            {
                DisplayName = "Billy",
                Email = email,
                Farm = null,
                FirstName = "None",
                IsConfirmedByMail = false,
                IsEnabled = false,
                LastName = "Gates",
                Password = "123",
                RoleType = RoleType.FarmCreator,
                TimeCreate = DateTime.UtcNow,
                TimeModify = DateTime.UtcNow
            };

            await _farmLabContext.User.AddAsync(userInDatabase);
            await _farmLabContext.SaveChangesAsync();

            var user = new UserItem
            {
                DisplayName = "Billy",
                Email = email,
                Farm = null,
                FirstName = "None",
                IsConfirmedByMail = false,
                IsEnabled = false,
                LastName = "Gates",
                Password = "123",
                RoleType = RoleType.FarmCreator,
                TimeCreate = DateTime.UtcNow,
                TimeModify = DateTime.UtcNow
            };

            // Act
            var userItem = await userRepository.GetUserAsync(user);

            // Assert
            userItem.Email.Should().Be(userInDatabase.Email);
            userItem.Id.Should().Be(userInDatabase.Id);
        }

        #endregion
    }
}
