using RentAppWebApi.Data;
using RentAppWebApi.Model;

namespace RentAppWebApi.Init
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Users.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Login = "admin",
                        Password = "admin",
                        Name = "TestUser_1",
                        Surname = "SomeSurmame",
                        PhotoPath = "photos/defalut.jpg",
                        Reviews = new List<Review>()
                    },
                    new User()
                    {
                        Login = "test",
                        Password = "test",
                        Name = "TestUser_2",
                        Surname = "SomeSurmame_2",
                        PhotoPath = "photos/defalut.jpg",
                        Reviews = new List<Review>()
                    }
                };                

                var country = new Country()
                {
                    Name = "Belarus"
                };

                var cities = new List<City>()
                {
                    new City() { Name="Minsk", Country = country },
                    new City() { Name="Brest", Country = country },
                    new City() { Name="Pinsk", Country = country }
                };

                country.Cities = cities;

                var landLord = new LandLord()
                {
                    User = users[0],
                    ReviewableObject = new ReviewableObject(),
                    Contracts = new List<Contract>(),
                    Advertisements = new List<Advertisement>(),
                    RealEstates = new List<RealEstate>()
                };

                var realEstate = new RealEstate()
                {
                    Description = "Two room apartment",
                    Location = "Lenin st. 1 a",
                    Country = country,
                    City = cities[0],
                    LandLord = landLord,
                    ReviewableObject = new ReviewableObject(),
                    Advertisements = new List<Advertisement>(),
                    Contracts = new List<Contract>()
                };

                cities[0].RealEstates = new List<RealEstate>() { realEstate };
                country.RealEstates = new List<RealEstate>() { realEstate };

                var photos = new List<PhotoOfRealEstate>()
                {
                    new PhotoOfRealEstate() { ImagePath = "photos/default.jpg", RealEstate = realEstate },
                    new PhotoOfRealEstate() { ImagePath = "photos/default.jpg", RealEstate = realEstate },
                    new PhotoOfRealEstate() { ImagePath = "photos/default.jpg", RealEstate = realEstate }
                };

                var advertisement = new Advertisement()
                {
                    Header = "Test Header",
                    Cost = 300,
                    Date = DateTime.Now,
                    TermInMonths = 6,
                    IsActual = true,
                    LandLord = landLord,
                    RealEstate = realEstate
                };

                var renter = new Renter()
                {
                    User = users[1],
                    ReviewableObject = new ReviewableObject(),
                    Contracts = new List<Contract>()
                };

                var contract = new Contract()
                {
                    Date = DateTime.Now,
                    TermInMonths = 6,
                    IsActual = true,
                    LandLord = landLord,
                    Renter = renter,
                    RealEstate = realEstate
                };

                realEstate.Photos = photos;
                realEstate.Advertisements.Add(advertisement);
                realEstate.Contracts.Add(contract);

                landLord.Advertisements.Add(advertisement);
                landLord.RealEstates.Add(realEstate);
                landLord.Contracts.Add(contract);

                renter.Contracts.Add(contract);

                var reviews = new List<Review>()
                {
                    new Review()
                    {
                        Comment = "Good one",
                        Rate = 5,
                        User = users[1],
                        ReviewableObjects = new List<ReviewableObject>() { realEstate.ReviewableObject }
                    },
                    new Review()
                    {
                        Comment = "Nice landlord!",
                        Rate = 5,
                        User = users[1],
                        ReviewableObjects = new List<ReviewableObject>() { landLord.ReviewableObject }
                    },
                    new Review()
                    {
                        Comment = "Nice person",
                        Rate = 5,
                        User = users[0],
                        ReviewableObjects = new List<ReviewableObject>() { renter.ReviewableObject }
                    }
                };

                users[1].Reviews.Add(reviews[0]);
                users[1].Reviews.Add(reviews[1]);
                users[0].Reviews.Add(reviews[2]);

                dataContext.Users.AddRange(users);
                dataContext.LandLords.Add(landLord);
                dataContext.Renters.Add(renter);

                dataContext.SaveChanges();
            }
        }        
    }
}
