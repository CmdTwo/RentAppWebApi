namespace RentAppWebApi.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public ContractItemDto Contract { get; set; }
        public bool AsRenter { get; set; }
    }
}
