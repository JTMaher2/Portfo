using System;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Portfo.API.Controllers.V1;
using Portfo.API.DataContracts;
using Portfo.API.DataContracts.Requests;
using Portfo.Services.Contracts;

namespace Portfo.API.Tests.Controllers.ControllerTests.V1
{
    [TestClass]
    public class UserControllerTests : TestBase
    {
        //NOTE: should be replaced by an interface
        readonly UserController _controller;

        public UserControllerTests() : base()
        {
            var businessService = _serviceProvider.GetRequiredService<IUserService>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<UserController>();

            _controller = new UserController(businessService, mapper, logger);
        }

        [TestMethod]
        public async Task CreateUser_Nominal_OK()
        {
            //Simple test
            var user = await _controller.CreateUser(new UserCreationRequest
            {
                Author = new UserCreation
                {
                    Address = new AddressUser()
                    {
                        AddressID = Guid.NewGuid()
                    },
                    Firstname = "test",
                    Lastname = "test"
                }
            });

            Assert.IsNotNull(user);
        }
    }
}
