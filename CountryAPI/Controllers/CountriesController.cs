using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryAPI.Repository;
using CountryAPI.Models;

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryrepository;
        public CountriesController(ICountryRepository countryrepository)
        {
            _countryrepository = countryrepository;
        }

        [HttpGet]
        public List<Country> GetCountry()
        {
            return _countryrepository.Get();
        }
        [HttpGet("{id}")]
        public Country GetCountry(int id)
        {
            return _countryrepository.Get(id);
        }
    }
}
