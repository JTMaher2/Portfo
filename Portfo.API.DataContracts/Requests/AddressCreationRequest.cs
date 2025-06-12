using System;

namespace Portfo.API.DataContracts.Requests
{
    /// <summary>
    /// Address creation request
    /// This follows a flow seggregation pattern to distingish commands from queries (ex: CQRS, etc).
    /// No specific framework has been used to avoid additional technical complexity.
    /// </summary>
    public class AddressCreationRequest
    {
        /// <summary>
        /// Address creation data
        /// </summary>
        public AddressCreation Address { get; set; }
    }
}
