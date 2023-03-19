namespace RentAppWebApi.Model
{
    public class PhotoOfRealEstate
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public RealEstate RealEstate { get; set; }
        public int RealEstateId { get; set; }
    }
}
