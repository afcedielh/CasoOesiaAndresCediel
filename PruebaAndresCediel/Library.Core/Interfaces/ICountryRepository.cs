using BookShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<DtoCountry>> GetCountry();
    }
}
