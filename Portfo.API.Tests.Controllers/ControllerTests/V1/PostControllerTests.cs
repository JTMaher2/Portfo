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
    public class PostControllerTests : TestBase
    {
        //NOTE: should be replaced by an interface
        readonly PostController _controller;

        public PostControllerTests() : base()
        {
            var businessService = _serviceProvider.GetRequiredService<IPostService>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<PostController>();

            _controller = new PostController(businessService, mapper, logger);
        }

        [TestMethod]
        public async Task CreatePost_Nominal_OK()
        {
            //Simple test
            var post = await _controller.CreatePost(new PostCreationRequest
            {
                Post = new PostCreation
                {
                    Description = "test",
                    Title = "test",
                    Author = new UserPost()
                    {
                        AuthorID = Guid.NewGuid()
                    }
                }
            });

            Assert.IsNotNull(post);
        }
    }
}


