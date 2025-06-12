namespace Portfo.Repo.SqlDatabase.DTO
{
    public class Address
    {
        public Guid ID { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}