using Microsoft.Extensions.DependencyInjection;

using Portfo.Services.Contracts;

namespace Portfo.Services.Tests
{
    [TestClass]
    public class AddressProjectServiceTests : TestBase
    {
        IAddressService _service;

        public AddressProjectServiceTests() : base()
        {
            _service = _serviceProvider.GetRequiredService<IAddressService>();
        }

        [TestMethod]
        public async Task CreateProject_Nominal_OK()
        {
            //Simple test
            var upsertResult = await _service.CreateAsync(
                 new Model.Address
                 {
                     AddressID = Guid.NewGuid(),
                     AddressCity = "test",
                     AddressCountry = "test",
                     CreationDate = DateTime.UtcNow,
                     AddressZipCode = "test",
                     AddressStreet = "test",
                     LastUpdateDate = DateTime.UtcNow
                 });

            Assert.IsNotNull(upsertResult);
        }
    }
}
