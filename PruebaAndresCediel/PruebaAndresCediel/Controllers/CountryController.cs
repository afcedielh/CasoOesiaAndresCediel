using BookShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICountryRepository _CountryRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CountryRepository"></param>
        public CountryController(ICountryRepository CountryRepository)
        {
            _CountryRepository = CountryRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> geCountry()
        {
            var writer = await _CountryRepository.GetCountry();
            return Ok(writer);
        }
    }
}
