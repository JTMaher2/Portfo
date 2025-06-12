using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

using Portfo.Services.Contracts;
using S = Portfo.Services.Model;

namespace Portfo.Services.Tests
{
    [TestClass]
    public class LikeProjectServiceTests : TestBase
    {
        ILikeService _service;

        public LikeProjectServiceTests() : base()
        {
            _service = _serviceProvider.GetRequiredService<ILikeService>();
        }

        [TestMethod]
        public async Task CreateProject_Nominal_OK()
        {
            //Simple test
            var upsertResult = await _service.CreateAsync(
                 new S.Like
                 {
                     LikeAuthor = new S.PostUser()
                     {
                         AuthorID = Guid.NewGuid()
                     },
                     LikeID = Guid.NewGuid(),
                     LikePost = new S.LikePost()
                     {
                         PostID = Guid.NewGuid()
                     },
                     CreationDate = DateTime.Now,
                     LastUpdateDate = DateTime.Now
                 });

            Assert.IsNotNull(upsertResult);
        }
    }
}
