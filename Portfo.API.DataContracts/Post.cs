using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Post datacontract summary to be replaced
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Post ID
        /// </summary>
        [DataType(DataType.Text)]
        public Guid PostID { get; set; }

        /// <summary>
        /// User who made post
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public UserPost PostAuthor { get; set; }

        /// <summary>
        /// Post title
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string PostTitle { get; set; }

        /// <summary>
        /// Post description
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string PostDescription { get; set; }

        /// <summary>
        /// Post creation date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Post last update date
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }
    }
}
