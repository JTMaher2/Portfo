using System;

namespace Portfo.API.DataContracts.Requests
{
    /// <summary>
    /// Generic request parameter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Request<T>
    {
        /// <summary>
        /// Request date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Request correlation id
        /// </summary>
        public string CorrelationID { get; set; }

        /// <summary>
        /// Request payload
        /// </summary>
        public T Payload { get; set; }
    }
}
