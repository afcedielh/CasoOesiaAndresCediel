using BookShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _CityRepository;

        public CityController(ICityRepository CityRepository)
        {
            _CityRepository = CityRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> geCountry(int id)
        {
            var Cities = await _CityRepository.GetCities(id);
            return Ok(Cities);
        }
    }
}
