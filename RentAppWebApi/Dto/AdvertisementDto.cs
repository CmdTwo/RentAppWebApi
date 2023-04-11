using RentAppWebApi.Model;

namespace RentAppWebApi.Dto
{
    public class AdvertisementDto
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
        public bool IsActual { get; set; }
        public UserItemDto LandLord { get; set; }
        public RealEstateExItemDto RealEstate { get; set; }
    }
}
