using AutoMapper;
using BookShop.Core.DTOs;
using BookShop.Core.Interfaces;
using BookShop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Infraestructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class WriterRepository : IWriterRepository
    {
        private readonly BookShopContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public WriterRepository(BookShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DtoWriter> GetWriter()
        {
            var writer = from w in _context.Writer
                         join c in _context.Cities on w.City equals c.Id
                         join co in _context.Country on c.Country equals co.Id
                         select new DtoWriter
                         {
                             City = c.Id,
                             Gender = w.Gender,
                             GenderStr = (bool)w.Gender ? "Masculino" : "Femenino",
                             Id = w.Id,
                             Nacionality = co.Name,
                             Name = w.Name,
                             CountryId = co.Id,
                             Books = w.Book.Count
                         };
            var writerDTO = _mapper.Map<IEnumerable<DtoWriter>>(writer);
            return writerDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DtoWriter GetWriter(int Id)
        {
            var writer = (from w in _context.Writer
                          join c in _context.Cities on w.City equals c.Id
                          join co in _context.Country on c.Country equals co.Id
                          where w.Id == Id
                          select new DtoWriter
                          {
                              City = c.Id,
                              Gender = w.Gender,
                              GenderStr = (bool)w.Gender ? "Masculino" : "Femenino",
                              Id = w.Id,
                              Nacionality = co.Name,
                              Name = w.Name,
                              CountryId = co.Id,
                              Books = w.Book.Count
                          }).FirstOrDefault();
            var writerDTO = _mapper.Map<DtoWriter>(writer);
            return writerDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int CreateWriter(DtoWriter Data)
        {
            var result = _context.Database
                .ExecuteSqlRaw("CreateWriter @p0, @p1, @p2"
                    , parameters: new[] { Data.City.ToString(),
                                          Data.Name,
                                          Data.Gender.ToString() });
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int UpdateWriter(DtoWriter Data)
        {
            var result = _context.Database
                .ExecuteSqlRaw("UpdateWriter @p0, @p1, @p2, @p3"
                    , parameters: new[] { Data.Id.ToString(),
                                          Data.City.ToString(),
                                          Data.Name,
                                          Data.Gender.ToString() });
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteWriter(int Id)
        {
            DtoWriter writer = GetWriter(Id);
            if (writer.Books == 0)
            {
                var result = _context.Database
                    .ExecuteSqlRaw("DeleteWriter @p0", parameters: new[] { Id.ToString() });
                return result;
            }
            else {
                return 0;
            }
        }
    }
}
