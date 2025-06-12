using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// User datacontract summary to be replaced
    /// </summary>
    public class UserPost
    {
        /// <summary>
        /// User Id
        /// </summary>
        [DataType(DataType.Text)]
        public Guid AuthorID { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [DataType(DataType.Text)]
        public string AuthorFirstname {get;set;}

        /// <summary>
        /// Last name
        /// </summary>
        [DataType(DataType.Text)]
        public string AuthorLastname {get;set;}
    }
}
