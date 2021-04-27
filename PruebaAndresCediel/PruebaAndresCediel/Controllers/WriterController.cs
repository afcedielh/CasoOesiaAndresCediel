using BookShop.Core.DTOs;
using BookShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IWriterRepository _writerRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WriterRepository"></param>
        public WriterController(IWriterRepository WriterRepository)
        {
            _writerRepository = WriterRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getWriter()
        {
            var writer = _writerRepository.GetWriter();
            return Ok(writer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult getWriter(int Id)
        {
            var writer = _writerRepository.GetWriter(Id);
            return Ok(writer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Writer(DtoWriter data)
        {
            var writer = _writerRepository.CreateWriter(data);
            return Ok(writer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(DtoWriter data)
        {
            var writer = _writerRepository.UpdateWriter(data);
            return Ok(writer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var writer = _writerRepository.DeleteWriter(Id);
            return Ok(writer);
        }
    }
}
