namespace RentAppWebApi.Dto
{
    public class AdvertisementItemDto
    {
        public int Id { get; set; }
        public int RealEsteteId { get; set; }
        public string Header { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
        public bool IsActual { get; set; }
        public UserItemDto LandLord { get; set; }
        public RealEstateItemDto RealEstate { get; set; }
    }
}
