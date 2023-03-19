namespace RentAppWebApi.Model
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
        public bool IsActual { get; set; }
        public LandLord LandLord { get; set; }
        public int LandLordId { get; set; }
        public Renter Renter { get; set; }
        public int RenterId { get; set; }
        public RealEstate RealEstate { get; set; }
        public int RealEstateId { get; set; }
    }
}
