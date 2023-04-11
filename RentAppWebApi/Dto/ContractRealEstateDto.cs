namespace RentAppWebApi.Dto
{
    public class ContractRealEstateDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
        public UserItemDto Renter { get; set; }
    }
}
