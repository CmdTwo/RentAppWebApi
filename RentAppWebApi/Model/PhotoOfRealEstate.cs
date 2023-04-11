using RentAppWebApi.Interface;

namespace RentAppWebApi.Model
{
    public class PhotoOfRealEstate : IModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public RealEstate RealEstate { get; set; }
        public int RealEstateId { get; set; }
    }
}
