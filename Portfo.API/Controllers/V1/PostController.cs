using System;
using System.Threading.Tasks;

using Asp.Versioning;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Portfo.API.DataContracts;
using Portfo.API.DataContracts.Requests;
using Portfo.Services.Contracts;

using S = Portfo.Services.Model;

namespace Portfo.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/posts")]//required for default versioning
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class PostController(IPostService service, IMapper mapper, ILogger<PostController> logger) : Controller
    {
        private readonly IPostService _service = service;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<PostController> _logger = logger;

        #region GET
        /// <summary>
        /// Returns a post entity according to the provided Id.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a post entity according to the provided Id.
        /// </returns>
        /// <response code="200">Returns the item with the provided Id.</response>
        /// <response code="204">If the item is null.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Post))]
        [HttpGet("{id}")]
        public async Task<Post> GetPost(string id)
        {
            _logger.LogDebug("PostControllers::Get::{id}", id);

            var data = await _service.GetAsync(new Guid(id));

            if (data != null)
                return _mapper.Map<Post>(data);
            else
                return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Creates a post.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created post.</returns>
        /// <response code="201">Returns the newly created item.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post))]
        public async Task<Post> CreatePost([FromBody] PostCreationRequest value)
        {
            ArgumentNullException.ThrowIfNull("value");

            if (value.Post == null)
            {
                throw new ArgumentNullException("value.Post");
            }

            if (value.Post.Author == null)
            {
                throw new ArgumentNullException("value.Post.Author");
            }

            if (value.Post.Description == null)
            {
                throw new ArgumentNullException("value.Post.Description");
            }

            if (value.Post.Title == null)
            {
                throw new ArgumentNullException("value.Post.Title");
            }

            if (value.Post.Author.AuthorID == Guid.Empty)
            {
                throw new ArgumentNullException("value.Post.Author.AuthorID");
            }

            var data = await _service.CreateAsync(_mapper.Map<S.Post>(value));

            if (data != null)
            {
                _logger.LogDebug("PostControllers::Post::{id}", data.PostID);

                return _mapper.Map<Post>(data);
            }
            else
            {
                _logger.LogDebug("PostControllers::Post::null");

                return null;
            }
        }
        #endregion

        #region PUT
        /// <summary>
        /// Updates an post entity.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="parameter"></param>
        /// <returns>
        /// Returns a boolean notifying if the post has been updated properly.
        /// </returns>
        /// <response code="200">Returns a boolean notifying if the post has been updated properly.</response>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> UpdatePost(PostUpdateRequest parameter)
        {
            _logger.LogDebug("PostControllers::Put::{id}", parameter.Post.ID);

            ArgumentNullException.ThrowIfNull("parameter");

            if (parameter.Post.Author == null)
            {
                throw new ArgumentNullException("parameter.Author");
            }

            if (parameter.Post.Author.AuthorID == Guid.Empty)
            {
                throw new ArgumentNullException("parameter.Author.AuthorID");
            }

            if (parameter.Post.Description == null)
            {
                throw new ArgumentNullException("parameter.Description");
            }

            if (parameter.Post.ID == Guid.Empty)
            {
                throw new ArgumentNullException("parameter.ID");
            }

            if (parameter.Post.Title == null)
            {
                throw new ArgumentNullException("parameter.Title");
            }

            var mapped = _mapper.Map<S.Post>(parameter);
            mapped.CreationDate = (await GetPost(mapped.PostID.ToString())).CreationDate;
            return await _service.UpdateAsync(mapped);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Deletes an post entity.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">Post Id</param>
        /// <returns>
        /// Boolean notifying if the post has been deleted properly.
        /// </returns>
        /// <response code="200">Boolean notifying if the post has been deleted properly.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> DeletePost(string id)
        {
            _logger.LogDebug("PostControllers::Delete::{id}", id);

            return await _service.DeleteAsync(id);
        }
        #endregion

        #region Exceptions
        /// <summary>
        /// Endpoint to raise an exception and test how the exceptions are handled.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("exception/{message}")]
        [ProducesErrorResponseType(typeof(Exception))]
        public Task RaiseException(string message)
        {
            _logger.LogDebug("PostControllers::RaiseException::{message}", message);

            throw new Exception(message);
        }
        #endregion
    }
}
