using Microsoft.Extensions.DependencyInjection;

using Portfo.Services.Contracts;
using S = Portfo.Services.Model;

namespace Portfo.Services.Tests
{
    [TestClass]
    public class UserProjectServiceTests : TestBase
    {
        IUserService _service;

        public UserProjectServiceTests() : base()
        {
            _service = _serviceProvider.GetRequiredService<IUserService>();
        }

        [TestMethod]
        public async Task CreateProject_Nominal_OK()
        {
            //Simple test
            var upsertResult = await _service.CreateAsync(
                 new S.User
                 {
                     AuthorFirstname = "test",
                     AuthorID = Guid.NewGuid(),
                     AuthorLastname = "test",
                     CreationDate = DateTime.Now,
                     AuthorAddress = new S.UserAddress()
                     {
                        AddressID = Guid.NewGuid()
                     },
                     LastUpdateDate = DateTime.UtcNow
                 });

            Assert.IsNotNull(upsertResult);
        }
    }
}
