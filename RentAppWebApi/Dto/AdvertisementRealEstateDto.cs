namespace RentAppWebApi.Dto
{
    public class AdvertisementRealEstateDto
    {
        public int Id { get; set; }        
        public string Header { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
    }
}
