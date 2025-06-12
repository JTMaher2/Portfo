using System;

namespace Portfo.Services.Model
{
    public class Like
    {
        public Guid LikeID { get; set; }
        public PostUser LikeAuthor { get; set; }
        public LikePost LikePost { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
