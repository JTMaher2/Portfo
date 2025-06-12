using System;

namespace Portfo.Services.Model.Requests
{
    public class Request<T>
    {
        public DateTime Date { get; set; }

        public string CorrelationID { get; set; }

        public T Payload { get; set; }
    }
}
