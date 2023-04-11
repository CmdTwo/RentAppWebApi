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
                            Reviews = new List<Review>(),
                            Advertisements = new List<Advertisement>(),
                            ContractsAsLandLord = new List<Contract>(),
                            ContractsAsRenter = new List<Contract>(),
                            RealEstates = new List<RealEstate>()
                        },
                        new User()
                        {
                            Login = "test",
                            Password = "test",
                            Name = "TestUser_2",
                            Surname = "SomeSurmame_2",
                            PhotoPath = "photos/defalut.jpg",
                            Reviews = new List<Review>(),
                            Advertisements = new List<Advertisement>(),
                            ContractsAsLandLord = new List<Contract>(),
                            ContractsAsRenter = new List<Contract>(),
                            RealEstates = new List<RealEstate>()
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

                var realEstate = new RealEstate()
                {
                    Description = "Two room apartment",
                    Location = "Lenin st. 1 a",
                    Country = country,
                    City = cities[0],
                    LandLord = users[0],
                    Advertisements = new List<Advertisement>(),
                    Contracts = new List<Contract>(),
                    Photos = new List<PhotoOfRealEstate>()
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
                    LandLord = users[0],
                    RealEstate = realEstate
                };

                var contract = new Contract()
                {
                    Date = DateTime.Now,
                    TermInMonths = 6,
                    IsActual = true,
                    RealEstate = realEstate,
                    Reviews = new List<Review>(),
                    LandLord = users[0],
                    Renter = users[1]
                };

                realEstate.Photos = photos;
                realEstate.Advertisements.Add(advertisement);
                realEstate.Contracts.Add(contract);

                users[0].Advertisements.Add(advertisement);
                users[0].RealEstates.Add(realEstate);
                users[0].ContractsAsLandLord.Add(contract);
                users[1].ContractsAsRenter.Add(contract);

                var reviews = new List<Review>()
                    {
                        new Review()
                        {
                            Comment = "Good one",
                            Rate = 5,
                            User = users[1],
                            Contract = contract
                        },
                        new Review()
                        {
                            Comment = "Nice person",
                            Rate = 5,
                            User = users[0],
                            Contract = contract
                        }
                    };

                contract.Reviews.Add(reviews[0]);
                contract.Reviews.Add(reviews[1]);

                users[1].Reviews.Add(reviews[0]);
                users[0].Reviews.Add(reviews[1]);

                dataContext.Users.AddRange(users);

                dataContext.SaveChanges();
            }
        }
    }
}