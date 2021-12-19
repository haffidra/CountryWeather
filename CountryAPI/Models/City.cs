using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryAPI.Models
{
    public class City
    {
        public int ID { get; set; }
        public int CountryID { get; set; }
        public string CityName { get; set; }
    }
}
