using System;

namespace Portfo.Services.Model
{
    public class User
    {
        public Guid AuthorID { get; set; }
        public string AuthorFirstname { get; set; }
        public string AuthorLastname { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public UserAddress AuthorAddress { get; set; }
    }
}
