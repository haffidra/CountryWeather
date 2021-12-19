using CountryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class CityRepository : ICityRepository
    {
        public List<City> listCity = new List<City>()
        {
            new City{ID=1,CountryID=1,CityName="Jakarta"},
            new City{ID=2,CountryID=1,CityName="Bandung"},
            new City{ID=3,CountryID=1,CityName="Malang"},
            new City{ID=4,CountryID=2,CityName="Tokyo"},
            new City{ID=5,CountryID=2,CityName="Osaka"},
            new City{ID=6,CountryID=3,CityName="London"},
            new City{ID=7,CountryID=4,CityName="Texas"},
            new City{ID=8,CountryID=4,CityName="New york"},
            new City{ID=9,CountryID=4,CityName="Misissipi"},
            new City{ID=10,CountryID=4,CityName="Los Angles"}
        };
        private readonly WeatherContext _context;
        public CityRepository(WeatherContext context)
        {
            _context = context;
        }
        public List<City> Get()
        {
            return listCity;
        }

        public List<City> GetCity(int countryID)
        {
            return listCity.Where(x => x.CountryID == countryID).ToList();
        }

        public City Get(int ID)
        {
            return listCity.FirstOrDefault(x => x.ID == ID);
        }
    }
}
