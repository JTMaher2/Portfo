using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Post datacontract summary to be replaced
    /// </summary>
    public class PostCreation
    {
        /// <summary>
        /// Post title
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        /// <summary>
        /// Post description
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        /// <summary>
        /// User who made post
        /// </summary>
        [Required]
        public UserPost Author { get; set; }
    }
}
