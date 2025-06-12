using Microsoft.Extensions.DependencyInjection;

using Portfo.Services.Contracts;

namespace Portfo.Services.Tests
{
    [TestClass]
    public class ActivityProjectServiceTests : TestBase
    {
        IActivityService _service;

        public ActivityProjectServiceTests() : base()
        {
            _service = _serviceProvider.GetRequiredService<IActivityService>();
        }

        [TestMethod]
        public async Task CreateProject_Nominal_OK()
        {
            //Simple test
            var upsertResult = await _service.CreateAsync(
                 new Model.Activity
                 {
                     ActivityID = Guid.NewGuid(),
                     ActivityOccuredAt = DateTime.UtcNow,
                     ActivityOperation = 1,
                     ActivityUser = new Model.PostUser()
                     {
                         AuthorID = Guid.NewGuid()
                     }
                 });

            Assert.IsNotNull(upsertResult);
        }
    }
}
