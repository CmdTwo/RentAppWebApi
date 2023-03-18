namespace RentAppWebApi.Model
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Term { get; set; }
        public bool IsActual { get; set; }
        public LandLord LandLord { get; set; }
        public Renter Renter { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
