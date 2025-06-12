using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Physical address
    /// </summary>
    public class AddressUser
    {
        /// <summary>
        /// Address ID
        /// </summary>
        [DataType(DataType.Text)]
        public Guid AddressID { get; set; }
    }
}
