using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public List<Country> listCountry = new List<Country>()
        {
            new Country{ID=1,CountryName="Indonesia"},
            new Country{ID=2,CountryName="Japan"},
            new Country{ID=3,CountryName="England"},
            new Country{ID=4,CountryName="America"}
        };

        private readonly WeatherContext _context;
        public CountryRepository(WeatherContext context)
        {
            _context = context;
        }
        public List<Country> Get()
        {
            return listCountry;
        }

        public Country Get(int ID)
        {
            return listCountry.FirstOrDefault(x => x.ID == ID);
        }
    }
}
