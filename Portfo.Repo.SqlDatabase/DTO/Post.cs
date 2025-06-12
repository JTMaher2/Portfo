namespace Portfo.Repo.SqlDatabase.DTO
{
    public class Post
    {
        public Guid ID { get; set; }
        public Guid AuthorID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}