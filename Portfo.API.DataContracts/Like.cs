using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Like datacontract summary to be replaced
    /// </summary>
    public class Like
    {
        /// <summary>
        /// Like ID
        /// </summary>
        [DataType(DataType.Text)]
        public Guid LikeID { get; set; }

        /// <summary>
        /// User who liked post
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public UserPost LikeAuthor { get; set; }

        /// <summary>
        /// Post that was liked by user
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public PostLike LikePost { get; set; }
        
        /// <summary>
        /// Like creation date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Like last update date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }
    }
}