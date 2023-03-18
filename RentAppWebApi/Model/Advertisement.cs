namespace RentAppWebApi.Model
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public DateTime Term { get; set; }
        public bool IsActual { get; set; }
        public LandLord PostedBy { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
