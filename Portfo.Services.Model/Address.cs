using System;

namespace Portfo.Services.Model
{
    public class Address
    {
        public Guid AddressID { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressCountry { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
