using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts.Requests
{
    /// <summary>
    /// Address update request
    /// This follows a flow seggregation pattern to distingish commands from queries (ex: CQRS, etc).
    /// No specific framework has been used to avoid additional technical complexity.
    /// </summary>
    public class AddressUpdateRequest
    {
        /// <summary>
        /// Address update date
        /// </summary>
        public AddressUpdate Address { get; set; }
    }
}
