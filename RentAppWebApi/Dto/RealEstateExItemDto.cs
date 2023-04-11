namespace RentAppWebApi.Dto
{
    public class RealEstateExItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public CityItemDto City { get; set; }
        public CountryItemDto Country { get; set; }
        public ICollection<string> Photos { get; set; }
    }
}
