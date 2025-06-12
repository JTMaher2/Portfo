using System;
using System.ComponentModel.DataAnnotations;

namespace Portfo.API.DataContracts
{
    /// <summary>
    /// Post datacontract summary to be replaced
    /// </summary>
    public class PostLike
    {
        /// <summary>
        /// Post ID
        /// </summary>
        [DataType(DataType.Text)]
        public Guid PostID { get; set; }
    }
}
