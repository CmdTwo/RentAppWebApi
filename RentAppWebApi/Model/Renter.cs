namespace RentAppWebApi.Model
{
    public class Renter
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ReviewableObject ReviewableObject { get; set; }
        public int ReviewableObjectId { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
