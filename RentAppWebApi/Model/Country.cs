namespace RentAppWebApi.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
