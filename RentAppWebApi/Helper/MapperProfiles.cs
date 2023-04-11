using AutoMapper;
using RentAppWebApi.Model;
using RentAppWebApi.Dto;

namespace RentAppWebApi.Helper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //Advertisement
            CreateMap<Advertisement, AdvertisementDto>();
            CreateMap<Advertisement, AdvertisementItemDto>();
            CreateMap<Advertisement, AdvertisementRealEstateDto>();

            //City
            CreateMap<City, CityItemDto>();

            //Country
            CreateMap<Country, CountryItemDto>();

            //RealEstate
            CreateMap<RealEstate, RealEstateItemDto>()
                .ForMember(vm => vm.MainPhoto, m => m.MapFrom(x => x.Photos.FirstOrDefault() == default
                    ? "photos/default.jpg" : x.Photos.FirstOrDefault().ImagePath));
            CreateMap<RealEstate, RealEstateItemViewDto>()
                .ForMember(vm => vm.MainPhoto, m => m.MapFrom(x => x.Photos.FirstOrDefault() == default
                    ? "photos/default.jpg" : x.Photos.FirstOrDefault().ImagePath));
            CreateMap<RealEstate, RealEstateExItemDto>()
                .ForMember(vm => vm.Photos, m => m.MapFrom(x => x.Photos.Select(y => y.ImagePath)));
            CreateMap<RealEstate, RealEstateDto>()
                .ForMember(vm => vm.Photos, m => m.MapFrom(x => x.Photos.Select(y => y.ImagePath)));

            //User
            //CreateMap<User, UserDto>();
            CreateMap<User, UserItemDto>();
            CreateMap<User, UserStatusItemDto>();

            //Contract
            CreateMap<Contract, ContractDto>();
            CreateMap<Contract, ContractItemDto>();
            CreateMap<Contract, ContractRealEstateDto>();

            //Review

            CreateMap<Review, ReviewDto>()
                .ForMember(vm => vm.AsRenter, m => m.MapFrom(x => x.Contract.RenterId == x.UserId));
            CreateMap<Review, ReviewAboutDto>();

        }
    }
}
