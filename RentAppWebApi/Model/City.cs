using RentAppWebApi.Interface;

namespace RentAppWebApi.Model
{
    public class City : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
    }
}
