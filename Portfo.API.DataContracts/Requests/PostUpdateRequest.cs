namespace Portfo.API.DataContracts.Requests
{
    /// <summary>
    /// Post update request
    /// This follows a flow seggregation pattern to distingish commands from queries (ex: CQRS, etc).
    /// No specific framework has been used to avoid additional technical complexity.
    /// </summary>
    public class PostUpdateRequest
    {
        /// <summary>
        /// Post update data
        /// </summary>
        public PostUpdate Post { get; set; }
    }
}
