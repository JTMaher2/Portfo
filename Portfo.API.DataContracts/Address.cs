using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Physical address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address ID
        /// </summary>
        [DataType(DataType.Text)]
        public Guid AddressID { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string AddressCity { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string AddressStreet { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string AddressZipCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string AddressCountry { get; set; }

        /// <summary>
        /// Address creation date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Address last update date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }
    }
}
