namespace Portfo.Repo.SqlDatabase.DTO
{
    public class User
    {
        public Guid ID { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required Guid AddressID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}