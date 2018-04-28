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
        public async Task Foo()
        {
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

            var userItem = await userRepository.GetUserAsync(user);

            userItem.Email.Should().Be(user.Email);
        }
    }
}
