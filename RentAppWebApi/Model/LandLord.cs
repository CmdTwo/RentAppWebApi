namespace RentAppWebApi.Model
{
    public class LandLord
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<RenterReview> LandLordReviews { get; set; }
        public ICollection<LandLordReview> RenterReviews { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
