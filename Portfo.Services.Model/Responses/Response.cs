using System;

namespace Portfo.Services.Model.Responses
{
    public class Response<T, R>
    {
        public T Request { get; set; }

        public string CorrelationID { get; set; }

        public DateTime ResponseDate { get; set; }

        public R ResponseContent { get; set; }

        public bool IsSuccessfull { get; set; }
        public string Error { get; set; }
    }
}
