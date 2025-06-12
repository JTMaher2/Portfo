using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using DC = Portfo.API.DataContracts;

namespace Portfo.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/activities")]//required for default versioning
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class ActivityController(IActivityService service, IMapper mapper, ILogger<ActivityController> logger) : Controller
    {
        private readonly IActivityService _service = service;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<ActivityController> _logger = logger;

        

        #region GET
        /// <summary>
        /// Returns a activity entity according to the provided Id.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <parameter>
        /// postID
        /// </parameter>
        /// <returns>
        /// Returns a activity entity according to the provided Id.
        /// </returns>
        /// <response code="200">Returns the item with the provided Id.</response>
        /// <response code="204">If the item is null.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DC.Activity))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(DC.Activity))]
        [HttpGet("{postID}")]
        public List<List<DC.Activity>> Get(string postID, int pagination)
        {
            _logger.LogDebug("ActivityControllers::Get");

            var data = _service.Get(new Guid(postID), pagination);

            if (data != null)
                return _mapper.Map<List<List<DC.Activity>>>(data);
            else
                return null;
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
            _logger.LogDebug("ActivityControllers::RaiseException::{message}", message);

            throw new Exception(message);
        }
        #endregion
    }
}
