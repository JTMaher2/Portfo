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
    [Route("api/users")]//required for default versioning
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class UserController(IUserService service, IMapper mapper, ILogger<UserController> logger) : Controller
    {
        private readonly IUserService _service = service;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<UserController> _logger = logger;

        #region GET
        /// <summary>
        /// Returns a user entity according to the provided Id.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a user entity according to the provided Id.
        /// </returns>
        /// <response code="200">Returns the item with the provided Id.</response>
        /// <response code="204">If the item is null.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(User))]
        [HttpGet("{id}")]
        public User Get(string id)
        {
            _logger.LogDebug("UserControllers::Get::{id}", id);

            var data = _service.GetAsync(new Guid(id));

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created user.</returns>
        /// <response code="201">Returns the newly created item.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
        public async Task<User> CreateUser([FromBody] UserCreationRequest value)
        {
            ArgumentNullException.ThrowIfNull("value");

            if (value.Author == null)
                throw new ArgumentNullException("value.Author");

            var data = await _service.CreateAsync(_mapper.Map<S.User>(value));

            if (data != null)
            {
                _logger.LogDebug("UserControllers::Post::{id}", data.AuthorID);

                return _mapper.Map<User>(data);
            }
            else
            {
                _logger.LogDebug("UserControllers::Post::null");

                return null;
            }
        }
        #endregion

        #region PUT
        /// <summary>
        /// Updates an user entity.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="parameter"></param>
        /// <returns>
        /// Returns a boolean notifying if the user has been updated properly.
        /// </returns>
        /// <response code="200">Returns a boolean notifying if the user has been updated properly.</response>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> UpdateUser(UserUpdateRequest parameter)
        {
            _logger.LogDebug("UserControllers::Put::{id}", parameter.Author.ID);

            ArgumentNullException.ThrowIfNull("parameter");

            var mapped = _mapper.Map<S.User>(parameter);
            mapped.CreationDate = Get(mapped.AuthorID.ToString()).CreationDate;
            mapped.LastUpdateDate = DateTime.UtcNow;

            return await _service.UpdateAsync(mapped);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Deletes an user entity.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">User Id</param>
        /// <returns>
        /// Boolean notifying if the user has been deleted properly.
        /// </returns>
        /// <response code="200">Boolean notifying if the user has been deleted properly.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> DeleteDevice(string id)
        {
            _logger.LogDebug("UserControllers::Delete::{id}", id);

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
            _logger.LogDebug("UserControllers::RaiseException::{message}", message);

            throw new Exception(message);
        }
        #endregion
    }
}
