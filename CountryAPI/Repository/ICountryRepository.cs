using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryAPI.Models;

namespace CountryAPI.Repository
{
    public interface ICountryRepository
    {
        List<Country> Get();
        Country Get(int ID);
    }
}
