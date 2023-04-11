using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentAppWebApi.Dto;
using RentAppWebApi.Interface;
using RentAppWebApi.Model;

namespace RentAppWebApi.Controllers
{
    [Route("api/contracts")]
    [ApiController]
    public class ContractController : Controller
    {
        private IContractRepository _contractRepository;
        private IRealEstateRepository _realEstateRepository;
        private IUserRepository _userRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private IPhotoOfRealEstateRepostitory _photoOfRealEstateRepostitory;
        private IMapper _mapper;

        public ContractController(IContractRepository contractRepository,
            IRealEstateRepository realEstateRepository, IUserRepository userRepository, 
            ICountryRepository countryRepository, ICityRepository cityRepository,
            IPhotoOfRealEstateRepostitory photoOfRealEstateRepostitory, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _realEstateRepository = realEstateRepository;
            _userRepository = userRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _photoOfRealEstateRepostitory = photoOfRealEstateRepostitory;

            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContractItemDto>))]
        public IActionResult GetContracts()
        {
            var items = _mapper.Map<List<ContractItemDto>>(_contractRepository
                .GetAllWithInclude(x => x.LandLord, x => x.Renter,
                    x => x.RealEstate, x => x.RealEstate.Country,
                    x => x.RealEstate.City, x => x.RealEstate.Photos));


            //var items = from contract in _contractRepository.Query()

            //            join landLord in _userRepository.Query()
            //            on contract.LandLordId equals landLord.Id

            //            join renter in _userRepository.Query()
            //            on contract.RenterId equals renter.Id

            //            join realEstate in _realEstateRepository.Query()
            //            on contract.RealEstateId equals realEstate.Id

            //            join country in _countryRepository.Query()
            //            on realEstate.CountryId equals country.Id

            //            join city in _cityRepository.Query()
            //            on realEstate.CityId equals city.Id

            //            //join photo in _photoOfRealEstateRepostitory.Query()
            //            //on realEstate.Id equals photo.RealEstateId

            //            orderby contract.Id

            //            select new ContractItemDto()
            //            {
            //                Id = contract.Id,
            //                Date = contract.Date,
            //                TermInMonths = contract.TermInMonths,
            //                IsActual = contract.IsActual,
            //                RealEstate = _mapper.Map<RealEstateItemDto>(realEstate),
            //                LandLord = _mapper.Map<UserItemDto>(landLord),
            //                Renter = _mapper.Map<UserItemDto>(renter)
            //            };

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items.ToList());
        }

        [HttpGet("{contractId}")]
        [ProducesResponseType(200, Type = typeof(ContractDto))]
        [ProducesResponseType(400)]
        public IActionResult GetContract(int contractId)
        {
            if (!_contractRepository.IsExist(contractId))
                return NotFound(ModelState);

            var item = _contractRepository
               .GetByIdWithInclude(contractId, x => x.LandLord,
                   x => x.Renter, x => x.RealEstate, x => x.RealEstate.Country,
                   x => x.RealEstate.City, x => x.RealEstate.Photos);

            var test = _mapper.Map<ContractDto>(item);

            if (item == null)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(test);
        }


    }
}
