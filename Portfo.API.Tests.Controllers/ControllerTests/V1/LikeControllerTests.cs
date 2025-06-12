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
    public class LikeControllerTests : TestBase
    {
        //NOTE: should be replaced by an interface
        readonly LikeController _controller;

        public LikeControllerTests() : base()
        {
            var businessService = _serviceProvider.GetRequiredService<ILikeService>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<LikeController>();

            _controller = new LikeController(businessService, mapper, logger);
        }

        [TestMethod]
        public async Task CreateLike_Nominal_OK()
        {
            //Simple test
            var like = await _controller.CreateLike(new LikeCreationRequest
            {
                Like = new LikeCreation()
                {
                    Author = new UserPost()
                    {
                        AuthorID = Guid.NewGuid()
                    },
                    Post = new PostLike()
                    {
                        PostID = Guid.NewGuid()
                    }
                }
            });

            Assert.IsNotNull(like);
        }
    }
}


