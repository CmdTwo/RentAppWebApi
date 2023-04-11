using RentAppWebApi.Interface;

namespace RentAppWebApi.Model
{
    public class Contract : IModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
        public bool IsActual { get; set; }
        public RealEstate RealEstate { get; set; }
        public int RealEstateId { get; set; }
        public User? LandLord { get; set; }
        public int? LandLordId { get; set; }
        public User? Renter { get; set; }
        public int? RenterId { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}