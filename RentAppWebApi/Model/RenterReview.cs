namespace RentAppWebApi.Model
{
    public class RenterReview
    {
        public int Id { get; set; }
        public Renter WritedBy { get; set; }
        public LandLord WritedAbout { get; set; }
        public Review Review { get; set; }
    }
}
