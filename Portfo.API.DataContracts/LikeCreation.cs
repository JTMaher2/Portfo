using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Like datacontract summary to be replaced
    /// </summary>
    public class LikeCreation
    {
        /// <summary>
        /// Liked post Id
        /// </summary>
        [Required]
        public PostLike Post { get; set; }

        /// <summary>
        /// User who liked post
        /// </summary>
        [Required]
        public UserPost Author {get;set;}
    }
}
