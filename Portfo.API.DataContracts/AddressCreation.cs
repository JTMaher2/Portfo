using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// User datacontract summary to be replaced
    /// </summary>
    public class AddressCreation
    {
        /// <summary>
        /// City
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Street { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Country { get; set; }
    }
}
