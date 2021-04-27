using BookShop.Core.DTOs;
using BookShop.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBookRepository _BookRepository;
        public BookController(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }

        [HttpGet]
        public IActionResult getBooks() {
            var books = _BookRepository.GetBooks();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Book(DtoBook data)
        {
            var books = _BookRepository.CreateBook(data);
            return Ok(books);
        }

        [HttpPut]
        public IActionResult UpdateBook(DtoBook data)
        {
            var books = _BookRepository.UpdateBook(data);
            return Ok(books);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var Book = _BookRepository.DeleteBook(Id);
            return Ok(Book);
        }
    }
}
