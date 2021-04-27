using AutoMapper;
using BookShop.Core.DTOs;
using BookShop.Core.Interfaces;
using BookShop.Infraestructure.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

namespace BookShop.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookShopContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int CreateBook(DtoBook data)
        {
            var result = _context.Database
                .ExecuteSqlRaw("CreateBook @p0, @p1, @p2, @p3"
                    , parameters: new[] { data.Name,
                        data.Date,
                        data.Price.ToString(),
                        data.Writer.ToString() });
            return result;
        }

        public int UpdateBook(DtoBook data)
        {
            var result = _context.Database
                .ExecuteSqlRaw("UpdateBook @p0, @p1, @p2, @p3, @p4"
                    , parameters: new[] { 
                        data.Id.ToString(),
                        data.Name,
                        data.Date,
                        data.Price.ToString(),
                        data.Writer.ToString() });
            return result;
        }

        public List<DtoBook> GetBooks()
        {
            try
            {
                var Books = from b in _context.Book
                            join w in _context.Writer on b.Writer equals w.Id
                            select new DtoBook
                            {
                                Date = ((DateTime)b.Date).ToString("dd/MM/yyyy"),
                                Id = b.Id,
                                Name = b.Name,
                                Price = (int)b.Price,
                                Writer = w.Id,
                                WriterName = w.Name
                            };
                var BooksDTO = _mapper.Map<IEnumerable<DtoBook>>(Books);
                return BooksDTO.ToList(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteBook(int data)
        {
            var result = _context.Database
                .ExecuteSqlRaw("DeleteBook @p0", parameters: new[] { data.ToString() });
            return result;
        }
    }
}
