using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentAppWebApi.Dto;
using RentAppWebApi.Interface;
using RentAppWebApi.Model;

namespace RentAppWebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private IContractRepository _contractRepository;
        private IRealEstateRepository _realEstateRepository;
        private IUserRepository _userRepository;
        private IAdvertisementRepository _advertisementRepository;
        private IReviewRepository _reviewRepository;
        private IMapper _mapper;

        public UserController(IUserRepository userRepository,
            IRealEstateRepository realEstateRepository,
            IContractRepository contractRepository,
            IAdvertisementRepository advertisementRepository,
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _realEstateRepository = realEstateRepository;
            _contractRepository = contractRepository;
            _advertisementRepository = advertisementRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserStatusItemDto>))]
        public IActionResult GetUsers()
        {
            var items = from user in _userRepository.Query()

                        join firstContract in _contractRepository.Query()
                        on user.Id equals firstContract.LandLordId into first
                        from x in first.DefaultIfEmpty()

                        join secondContract in _contractRepository.Query()
                        on user.Id equals secondContract.RenterId into second
                        from y in second.DefaultIfEmpty()

                        select new UserStatusItemDto()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            PhotoPath = user.PhotoPath,
                            IsLandLord = !(x == null),
                            IsRenter = !(y == null)
                        };

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items.Distinct().OrderBy(x => x.Id));
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserItemDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            //if (!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var item = _mapper.Map<UserItemDto>(_userRepository.GetById(userId));

            if(item == null)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(item);
        }

        [HttpGet("{userId}/contracts/landlord")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContractItemDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetContractsByLandLord(int userId)
        {
            //if(!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var items = _mapper.Map<List<ContractItemDto>>(_contractRepository
                .GetAllWithInclude(x => x.LandLord, x => x.Renter,
                    x => x.RealEstate, x => x.RealEstate.Country,
                    x => x.RealEstate.City, x => x.RealEstate.Photos)
                .Where(x => x.LandLordId == userId));

            if (items == null || items.Count == 0)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }

        [HttpGet("{userId}/contracts/renter")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContractItemDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetContractsByRenter(int userId)
        {
            //if (!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var items = _mapper.Map<List<ContractItemDto>>(_contractRepository
                .GetAllWithInclude(x => x.LandLord, x => x.Renter,
                    x => x.RealEstate, x => x.RealEstate.Country,
                    x => x.RealEstate.City, x => x.RealEstate.Photos)
                .Where(x => x.RenterId == userId));

            if (items == null || items.Count == 0)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }

        [HttpGet("{userId}/ads")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContractItemDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAdsByUser(int userId)
        {
            //if (!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var items = _mapper.Map<List<AdvertisementItemDto>>(_advertisementRepository
               .GetAllWithInclude(x => x.LandLord,
                   x => x.RealEstate, x => x.RealEstate.Country,
                   x => x.RealEstate.City, x => x.RealEstate.Photos)
                .Where(x => x.LandLordId == userId));

            if (items == null || items.Count == 0)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }

        [HttpGet("{userId}/realestates")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RealEstateItemDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetRealEstatesByUser(int userId)
        {
            //if (!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var items = _mapper.Map<List<RealEstateItemDto>>(_realEstateRepository
               .GetAllWithInclude(x => x.Country,
                   x => x.City, x => x.Photos)
                .Where(x => x.LandLordId == userId));

            if (items == null || items.Count == 0)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }

        [HttpGet("{userId}/reviews")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RealEstateItemDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByUser(int userId)
        {
            //if (!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var items = _mapper.Map<List<ReviewDto>>(_reviewRepository
               .GetAllWithInclude(x => x.Contract, x => x.User, 
                   x => x.Contract.RealEstate, x => x.Contract.RealEstate.City,
                   x => x.Contract.RealEstate.Country, x => x.Contract.RealEstate.Photos,
                   x => x.Contract.LandLord, x => x.Contract.Renter)
                .Where(x => x.UserId == userId));

            if (items == null || items.Count == 0)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }
        [HttpGet("{userId}/reviews/about")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewAboutDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsAboutUser (int userId)
        {
            //if (!_userRepository.IsExist(userId))
            //    return NotFound(ModelState);

            var items = _mapper.Map<List<ReviewAboutDto>>(_reviewRepository
               .GetAllWithInclude(x => x.Contract, x => x.User,
                   x => x.Contract.RealEstate)
                .Where(x => x.Contract.RealEstateId == userId)
                .Where(x => x.UserId == x.Contract.LandLordId));

            if (items == null || items.Count == 0)
                return NotFound(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }
    }
}
