using System;

namespace Portfo.Services.Model
{
    public class Post
    {
        public Guid PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription {get;set;}
        public PostUser PostAuthor { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
