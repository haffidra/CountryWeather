using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryAPI.Repository;
using CountryAPI.Models;

namespace CityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _Cityrepository;
        public CitiesController(ICityRepository Cityrepository)
        {
            _Cityrepository = Cityrepository;
        }

        [HttpGet]
        public List<City> GetCity()
        {
            return _Cityrepository.Get();
        }
        [HttpGet("bycountry/{countryid}")]
        public List<City> GetCityByCountry(int countryID)
        {
            return _Cityrepository.GetCity(countryID);
        }
        [HttpGet("{id}")]
        public City GetCity(int id)
        {
            return _Cityrepository.Get(id);
        }
    }
}
