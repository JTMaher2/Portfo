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
    [Route("api/likes")]//required for default versioning
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class LikeController(ILikeService service, IMapper mapper, ILogger<LikeController> logger) : Controller
    {
        private readonly ILikeService _service = service;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<LikeController> _logger = logger;

        #region POST
        /// <summary>
        /// Creates a like.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created like.</returns>
        /// <response code="201">Returns the newly created item.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Like))]
        public async Task<Like> CreateLike([FromBody] LikeCreationRequest value)
        {
            ArgumentNullException.ThrowIfNull("value");

            if (value.Like == null)
            {
                throw new ArgumentNullException("value.Like");
            }

            if (value.Like.Author == null)
            {
                throw new ArgumentNullException("value.Like.Author");
            }

            if (value.Like.Post == null)
            {
                throw new ArgumentNullException("value.Like.Post");
            }

            var data = await _service.CreateAsync(_mapper.Map<S.Like>(value));

            if (data != null)
            {
                _logger.LogDebug("LikeControllers::Post::{id}", data.LikeID);
                return _mapper.Map<Like>(data);
            }
            else
            {
                _logger.LogDebug("LikeControllers::Post::null");
                return null;
            }
        }
        #endregion
        #region DELETE
        /// <summary>
        /// Deletes a like entity.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">Like Id</param>
        /// <returns>
        /// Boolean notifying if the like has been deleted properly.
        /// </returns>
        /// <response code="200">Boolean notifying if the like has been deleted properly.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> DeleteDevice(string id)
        {
            _logger.LogDebug("LikeControllers::Delete::{id}", id);

            return await _service.DeleteAsync(id);
        }
        #endregion
    }
}
