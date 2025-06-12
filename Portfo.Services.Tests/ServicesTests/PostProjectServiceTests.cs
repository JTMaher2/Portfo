using Microsoft.Extensions.DependencyInjection;

using Portfo.Services.Contracts;
using S = Portfo.Services.Model;

namespace Portfo.Services.Tests
{
    [TestClass]
    public class PostProjectServiceTests : TestBase
    {
        IPostService _service;

        public PostProjectServiceTests() : base()
        {
            _service = _serviceProvider.GetRequiredService<IPostService>();
        }

        [TestMethod]
        public async Task CreateProject_Nominal_OK()
        {
            //Simple test
            var upsertResult = await _service.CreateAsync(
                 new S.Post
                 {
                     CreationDate = DateTime.Now,
                     PostDescription = "test",
                    
                     PostID = Guid.NewGuid(),
                     PostTitle = "test",
                     PostAuthor = new S.PostUser()
                     {
                        AuthorID = Guid.NewGuid()
                     }
                 });

            Assert.IsNotNull(upsertResult);
        }
    }
}
