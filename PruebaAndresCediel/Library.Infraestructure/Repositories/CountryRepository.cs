using AutoMapper;
using BookShop.Core.DTOs;
using BookShop.Core.Interfaces;
using BookShop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infraestructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BookShopContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(BookShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DtoCountry>> GetCountry()
        {
            try
            {
                var countries = await _context.Country.ToListAsync();
                var countriesDTO = _mapper.Map<List<DtoCountry>>(countries);
                return countriesDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
