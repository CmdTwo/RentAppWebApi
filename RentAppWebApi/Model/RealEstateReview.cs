namespace RentAppWebApi.Model
{
    public class RealEstateReview
    {
        public int Id { get; set; }
        public Renter WritedBy { get; set; }
        public RealEstate WritedAbout { get; set; }
        public Review Review { get; set; }
    }
}
