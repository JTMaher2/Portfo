using System;
using System.ComponentModel.DataAnnotations;
using Portfo.Services.Model;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Like datacontract summary to be replaced
    /// </summary>
    public class LikeUpdate
    {
        /// <summary>
        /// Like ID
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public Guid ID { get; set; }

        /// <summary>
        /// User who liked post
        /// </summary>
        [Required]
        public UserPost Author { get; set; }

        /// <summary>
        /// Post that was liked by user
        /// </summary>
        [Required]
        public PostLike Post { get; set; }
    }
}