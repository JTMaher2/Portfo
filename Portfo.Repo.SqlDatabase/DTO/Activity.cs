namespace Portfo.Repo.SqlDatabase.DTO
{
    public class Activity
    {
        public enum Type
        {
            CREATE,
            UPDATE,
            DELETE,
            LIKE,
            UNLIKE
        }

        public Guid ID { get; set; }
       
        public Guid AuthorID {get;set;}
        public byte Operation {get;set;}
        public DateTime OccuredAt {get;set;}
        public Guid PostID { get; set; }
        public required string AuthorFirstname {get;set;}
        public required string AuthorLastname {get;set;}
    }
}