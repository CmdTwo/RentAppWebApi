namespace RentAppWebApi.Model
{
    public class LandLordReview
    {
        public int Id { get; set; }
        public LandLord WritedBy { get; set; }
        public Renter WritedAbout { get; set; }
        public Review Review { get; set; }
    }
}
