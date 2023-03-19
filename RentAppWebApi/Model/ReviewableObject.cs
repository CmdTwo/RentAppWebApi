namespace RentAppWebApi.Model
{
    public class ReviewableObject
    {
        public int Id { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
