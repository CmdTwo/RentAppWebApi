using RentAppWebApi.Interface;

namespace RentAppWebApi.Model
{
    public class Review : IModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Contract Contract { get; set; }
        public int ContractId { get; set; }
    }
}
