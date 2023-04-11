namespace RentAppWebApi.Dto
{
    public class ContractItemDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TermInMonths { get; set; }
        public bool IsActual { get; set; }
        public RealEstateItemDto RealEstate { get; set; }
        public UserItemDto LandLord { get; set; }
        public UserItemDto Renter { get; set; }
    }
}
