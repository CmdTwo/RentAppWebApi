namespace RentAppWebApi.Dto
{
    public class UserStatusItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; }
        public bool IsLandLord { get; set; }
        public bool IsRenter { get; set; }
    }
}
