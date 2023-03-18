namespace RentAppWebApi.Model
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public LandLord Owner { get; set; }
        public int MyProperty { get; set; }
        public ICollection<PhotoOfRealEstate> Photos { get; set; }
    }
}
