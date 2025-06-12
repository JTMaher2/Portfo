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
    public class AddressControllerTests : TestBase
    {
        //NOTE: should be replaced by an interface
        readonly AddressController _controller;

        public AddressControllerTests() : base()
        {
            var businessService = _serviceProvider.GetRequiredService<IAddressService>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<AddressController>();

            _controller = new AddressController(businessService, mapper, logger);
        }

        [TestMethod]
        public async Task CreateAddress_Nominal_OK()
        {
            //Simple test
            var address = await _controller.CreateAddress(new AddressCreationRequest
            {
                Address = new AddressCreation()
                {
                    City = "Wheaton",
                    Country = "USA",
                    Street = "216 E. Union Ave.",
                    ZipCode = "60187"
                }
            });

            Assert.IsNotNull(address);
        }
    }
}


