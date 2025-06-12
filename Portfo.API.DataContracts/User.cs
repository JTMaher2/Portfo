using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// User datacontract summary to be replaced
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        [DataType(DataType.Text)]
        public Guid AuthorID { get; set; }

        /// <summary>
        /// User firstname
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string AuthorFirstname { get; set; }

        /// <summary>
        /// User lastname
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string AuthorLastname { get; set; }

        /// <summary>
        /// User creation date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// User last update date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// User address
        /// </summary>
        [Required]
        public AddressUser AuthorAddress { get; set; }
    }
}
