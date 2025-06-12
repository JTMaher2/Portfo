using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// User datacontract summary to be replaced
    /// </summary>
    public class UserCreation
    {
        /// <summary>
        /// User firstname
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        /// <summary>
        /// User lastname
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        /// <summary>
        /// User address
        /// </summary>
        [Required]
        public AddressUser Address { get; set; }
    }
}
