namespace Portfo.API.DataContracts.Requests
{
    /// <summary>
    /// User update request
    /// This follows a flow seggregation pattern to distingish commands from queries (ex: CQRS, etc).
    /// No specific framework has been used to avoid additional technical complexity.
    /// </summary>
    public class UserUpdateRequest
    {
        /// <summary>
        /// User update data
        /// </summary>
        public UserUpdate Author { get; set; }
    }
}
