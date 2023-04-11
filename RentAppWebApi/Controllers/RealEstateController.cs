using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentAppWebApi.Dto;
using RentAppWebApi.Interface;
using RentAppWebApi.Model;

namespace RentAppWebApi.Controllers
{
    [Route("api/realestates")]
    [ApiController]
    public class RealEstateController : Controller
    {
        private IContractRepository _contractRepository;
        private IRealEstateRepository _realEstateRepository;
        private IUserRepository _userRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private IPhotoOfRealEstateRepostitory _photoOfRealEstateRepostitory;
        private IAdvertisementRepository _advertisementRepository;
        private IReviewRepository _reviewRepository;
        private IMapper _mapper;

        public RealEstateController(IContractRepository contractRepository,
            IRealEstateRepository realEstateRepository, IUserRepository userRepository,
            ICountryRepository countryRepository, ICityRepository cityRepository,
            IPhotoOfRealEstateRepostitory photoOfRealEstateRepostitory,
            IAdvertisementRepository advertisementRepository, 
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _contractRepository = contractRepository;
            _realEstateRepository = realEstateRepository;
            _userRepository = userRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _photoOfRealEstateRepostitory = photoOfRealEstateRepostitory;
            _advertisementRepository = advertisementRepository;
            _reviewRepository = reviewRepository;

            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RealEstateItemViewDto>))]
        public IActionResult GetRealEstates()
        {
            var items = _mapper.Map<List<RealEstateItemViewDto>>(_realEstateRepository
                .GetAllWithInclude(x => x.Country, x => x.City,
                x => x.Photos, x => x.LandLord));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items.ToList());
        }

        [HttpGet("{realEstateId}")]
        [ProducesResponseType(200, Type = typeof(RealEstateDto))]
        [ProducesResponseType(400)]
        public IActionResult GetRealEstate(int realEstateId)
        {
            if (!_realEstateRepository.IsExist(realEstateId))
                return NotFound(ModelState);

            var item = _mapper.Map<RealEstateDto>(_realEstateRepository
               .GetByIdWithInclude(realEstateId, x => x.LandLord,
                   x => x.Country, x => x.City, x => x.Photos,
                   x => x.Advertisements, x => x.Contracts));

            //var photos = from realEstate in _realEstateRepository.Query()
            //             join photo in _photoOfRealEstateRepostitory.Query()
            //             on realEstate.Id equals photo.RealEstateId
            //             select new { photo };

            //var ads = from realEstate in _realEstateRepository.Query()
            //             join ad in _advertisementRepository.Query()
            //             on realEstate.Id equals ad.RealEstateId
            //             select new { ad };

            //var contracts = from realEstate in _realEstateRepository.Query()
            //             join contract in _contractRepository.Query()
            //             on realEstate.Id equals contract.RealEstateId
            //             select new { contract };

            //contracts = from contract in contracts
            //           join renter in _userRepository.Query()
            //           on contract.contract.RenterId equals renter.Id
            //           select new { contract.contract };

            //var item = (from realEstate in _realEstateRepository.Query()

            //            join city in _cityRepository.Query()
            //            on realEstate.CityId equals city.Id

            //            join country in _countryRepository.Query()
            //            on realEstate.CountryId equals country.Id

            //            join landlord in _userRepository.Query()
            //            on realEstate.LandLordId equals landlord.Id

            //            where realEstate.Id == realEstateId
            //            orderby realEstate.Id

            //            select new RealEstateDto()
            //            {
            //                Id = realEstate.Id,
            //                Description = realEstate.Description,
            //                Location = realEstate.Location,
            //                City = _mapper.Map<CityItemDto>(city),
            //                Country = _mapper.Map<CountryItemDto>(country),
            //                LandLord = _mapper.Map<UserItemDto>(landlord),
            //                Photos = photos.Select(x => x.photo.ImagePath).ToList(),
            //                Advertisements = _mapper.Map<List<AdvertisementRealEstateDto>>
            //                    (ads.Select( x => x.ad)),
            //                Contracts = _mapper.Map<List<ContractRealEstateDto>>
            //                    (contracts.Select( x => x.contract))
            //            }).Take(1);

            if (item == null)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(item);
        }

        [HttpGet("{realEstateId}/reviews")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewAboutDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByRealEstate(int realEstateId)
        {
            //if (!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var items = _mapper.Map<List<ReviewAboutDto>>(_reviewRepository
               .GetAllWithInclude(x => x.Contract, x => x.User,
                   x => x.Contract.RealEstate)
                .Where(x => x.Contract.RealEstateId == realEstateId)
                .Where(x => x.UserId == x.Contract.RenterId));
                    

            if (items == null || items.Count == 0)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }
    }
}
