namespace RentAppWebApi.Model
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public LandLord LandLord { get; set; }
        public int LandLordId { get; set; }
        public ReviewableObject ReviewableObject { get; set; }
        public int ReviewableObjectId { get; set; }
        public ICollection<PhotoOfRealEstate> Photos { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
