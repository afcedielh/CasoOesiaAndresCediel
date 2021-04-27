using AutoMapper;
using BookShop.Core.DTOs;
using BookShop.Core.Interfaces;
using BookShop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Infraestructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly BookShopContext _context;
        private readonly IMapper _mapper;

        public CityRepository(BookShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DtoCity>> GetCities(int idCountry)
        {
            try
            {
                var Cities = await _context.Cities.Where(a => a.Country == idCountry).ToListAsync();
                var CitiesDTO = _mapper.Map<List<DtoCity>>(Cities);
                return CitiesDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
    }
}
