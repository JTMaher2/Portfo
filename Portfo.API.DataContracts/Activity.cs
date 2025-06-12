using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Physical Activity
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// User ID
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public UserPost ActivityUser { get; set; }

        /// <summary>
        /// Operation
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public byte ActivityOperation { get; set; }

        /// <summary>
        /// Occured at
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ActivityOccuredAt { get; set; }
    }
}
