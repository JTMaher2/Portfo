namespace Portfo.Repo.SqlDatabase.DTO
{
    public class Like
    {
        public Guid ID { get; set; }
        public Guid AuthorID { get; set; }
        public Guid PostID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}