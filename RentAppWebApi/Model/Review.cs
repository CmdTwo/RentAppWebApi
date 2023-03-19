namespace RentAppWebApi.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<ReviewableObject> ReviewableObjects { get; set; }
    }
}
