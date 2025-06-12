namespace Portfo.API.DataContracts.Requests
{
    /// <summary>
    /// Like update request
    /// This follows a flow seggregation pattern to distingish commands from queries (ex: CQRS, etc).
    /// No specific framework has been used to avoid additional technical complexity.
    /// </summary>
    public class LikeUpdateRequest
    {
        /// <summary>
        /// Like update data
        /// </summary>
        public LikeUpdate Like { get; set; }
    }
}
