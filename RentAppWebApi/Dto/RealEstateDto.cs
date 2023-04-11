namespace RentAppWebApi.Dto
{
    public class RealEstateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public CityItemDto City { get; set; }
        public CountryItemDto Country { get; set; }
        public UserItemDto LandLord { get; set; }
        public ICollection<string> Photos { get; set; }
        public ICollection<AdvertisementRealEstateDto> Advertisements { get; set; }
        public ICollection<ContractRealEstateDto> Contracts { get; set; }
    }
}
