using RentAppWebApi.Interface;

namespace RentAppWebApi.Model
{
    public class User : IModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<Contract>? ContractsAsLandLord { get; set; }
        public ICollection<Contract>? ContractsAsRenter { get; set; }
        public ICollection<RealEstate> RealEstates { get; set; }
    }
}
