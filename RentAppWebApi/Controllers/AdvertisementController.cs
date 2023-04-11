using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentAppWebApi.Dto;
using RentAppWebApi.Interface;
using RentAppWebApi.Model;
using RentAppWebApi.Helper;

namespace RentAppWebApi.Controllers
{
    [Route("api/ads")]
    [ApiController]
    public class AdvertisementController : Controller
    {
        private IAdvertisementRepository _advertisementRepository;
        private IMapper _mapper;

        public AdvertisementController(IAdvertisementRepository advertisementRepository,
            IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Advertisement>))]
        public IActionResult GetAdvertisements()
        {
            var items = _mapper.Map<List<AdvertisementItemDto>>(_advertisementRepository
                .GetAllWithInclude(x => x.LandLord,
                    x => x.RealEstate, x => x.RealEstate.Country,
                    x => x.RealEstate.City, x => x.RealEstate.Photos));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }

        [HttpGet("{adId}")]
        [ProducesResponseType(200, Type = typeof(AdvertisementDto))]
        [ProducesResponseType(400)]
        public IActionResult GetAdvertisementById(int adId)
        {
            if (!_advertisementRepository.IsExist(adId))
                return NotFound();

            var item = _mapper.Map<AdvertisementDto>(_advertisementRepository
                .GetByIdWithInclude(adId, x => x.LandLord,
                    x => x.RealEstate, x => x.RealEstate.Country,
                    x => x.RealEstate.City, x => x.RealEstate.Photos));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(item);
        }
    }
}
