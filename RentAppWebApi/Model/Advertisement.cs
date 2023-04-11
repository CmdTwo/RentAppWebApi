using RentAppWebApi.Interface;

namespace RentAppWebApi.Model
{
    public class Advertisement : IModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
        public bool IsActual { get; set; }
        public User LandLord { get; set; }
        public int LandLordId { get; set; }
        public RealEstate RealEstate { get; set; }
        public int RealEstateId { get; set; }
    }
}
