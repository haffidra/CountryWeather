using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryAPI.Models;

namespace CountryAPI.Repository
{
    public interface ICityRepository
    {
        List<City> Get();
        List<City> GetCity(int countryID);
        City Get(int ID);
    }
}
