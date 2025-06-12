using System;

namespace Portfo.API.DataContracts.Requests
{
    /// <summary>
    /// User creation request
    /// This follows a flow seggregation pattern to distingish commands from queries (ex: CQRS, etc).
    /// No specific framework has been used to avoid additional technical complexity.
    /// </summary>
    public class LikeCreationRequest
    {
        /// <summary>
        /// Like
        /// </summary>
        public LikeCreation Like { get; set; }
    }
}
