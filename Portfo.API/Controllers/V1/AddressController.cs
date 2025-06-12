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
    [Route("api/addresses")]//required for default versioning
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class AddressController(IAddressService service, IMapper mapper, ILogger<AddressController> logger) : Controller
    {
        private readonly IAddressService _service = service;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<AddressController> _logger = logger;

        #region GET
        /// <summary>
        /// Returns a address entity according to the provided Id.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a address entity according to the provided Id.
        /// </returns>
        /// <response code="200">Returns the item with the provided Id.</response>
        /// <response code="204">If the item is null.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Address))]
        [HttpGet("{id}")]
        public Address Get(string id)
        {
            _logger.LogDebug("AddressControllers::Get::{id}", id);

            var data = _service.GetAsync(new Guid(id));

            if (data != null)
                return _mapper.Map<Address>(data);
            else
                return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Creates a address.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created address.</returns>
        /// <response code="201">Returns the newly created item.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Address))]
        public async Task<Address> CreateAddress([FromBody] AddressCreationRequest value)
        {
            ArgumentNullException.ThrowIfNull("value");

            if (value.Address == null)
            {
                throw new ArgumentNullException("value.Address");
            }

            if (value.Address.City == null)
            {
                throw new ArgumentNullException("value.Address.City");
            }

            if (value.Address.Country == null)
            {
                throw new ArgumentNullException("value.Address.Country");
            }

            if (value.Address.Street == null)
            {
                throw new ArgumentNullException("value.Address.Street");
            }

            if (value.Address.ZipCode == null)
            {
                throw new ArgumentNullException("value.Address.ZipCode");
            }
            
            var data = await _service.CreateAsync(_mapper.Map<S.Address>(value));

            if (data != null)
            {
                _logger.LogDebug("AddressControllers::Post::{id}", data.AddressID);
                return _mapper.Map<Address>(data);
            }
            else
            {
                _logger.LogDebug("AddressControllers::Post::null");
                return null;
            }
        }
        #endregion

        #region PUT
        /// <summary>
        /// Updates an address entity.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="parameter"></param>
        /// <returns>
        /// Returns a boolean notifying if the address has been updated properly.
        /// </returns>
        /// <response code="200">Returns a boolean notifying if the address has been updated properly.</response>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> UpdateAddress(AddressUpdateRequest parameter)
        {
            _logger.LogDebug("AddressControllers::Put::{id}", parameter.Address.ID);

            ArgumentNullException.ThrowIfNull("parameter");

            var mapped = _mapper.Map<S.Address>(parameter);
            mapped.CreationDate = Get(mapped.AddressID.ToString()).CreationDate;
            mapped.LastUpdateDate = DateTime.UtcNow;

            return await _service.UpdateAsync(mapped);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Deletes an address entity.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">Address Id</param>
        /// <returns>
        /// Boolean notifying if the address has been deleted properly.
        /// </returns>
        /// <response code="200">Boolean notifying if the address has been deleted properly.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> DeleteDevice(string id)
        {
            _logger.LogDebug("AddressControllers::Delete::{id}", id);

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
            _logger.LogDebug("AddressControllers::RaiseException::{message}", message);

            throw new Exception(message);
        }
        #endregion
    }
}
