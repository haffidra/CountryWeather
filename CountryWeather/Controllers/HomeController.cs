using CountryWeather.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Net.Http;

namespace CountryWeather.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SelectList lstCountry = new SelectList(GetAllCountry(), "ID", "CountryName");
            ViewData["ddlCountry"] = lstCountry;
            return View();
        }

        private static List<Country> GetAllCountry()
        {
            List<Country> list = new List<Country>();
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("http://localhost:29022/api/countries").Result;
                if (response.IsSuccessStatusCode)
                {
                    list = JsonConvert.DeserializeObject<List<Country>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            { }
            return list;
        }

        [HttpGet]
        public JsonResult GetCityByCountry(int countryID)
        {
            List<City> list = new List<City>();
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("http://localhost:29022/api/cities/bycountry/" + countryID).Result;
                if (response.IsSuccessStatusCode)
                {
                    list = JsonConvert.DeserializeObject<List<City>>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            { }
            return Json(new { success = true, data = list });
        }

        [HttpGet]
        public JsonResult GetWeatherByCity(string city)
        {
            RootObject temp = new RootObject();
            CurrentWeather current = new CurrentWeather();
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(string.Format("http://api.openweathermap.org/data/2.5/weather?q={0},uk&APPID=71ae8b5d39aff619f44171846c6e5b7f", city)).Result;
                if (response.IsSuccessStatusCode)
                {
                    temp = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
                    current.Location = string.Format("Longitude = {0}, Latitude = {1}", temp.coord.lon, temp.coord.lat);
                    current.Pressure = temp.main.pressure.ToString();
                    current.RelativeHumidity = temp.main.humidity.ToString();
                    current.Visibility = temp.visibility.ToString();
                    current.Wind = temp.wind.speed.ToString();
                    current.SkyCondition = temp.weather.Count > 0 ? temp.weather[0].main.ToString() : string.Empty;
                    current.Temperature = temp.main.temp.ToString();
                    current.DewPoint = temp.dt.ToString();
                    current.Time = temp.timezone.ToString();
                }
            }
            catch (Exception ex)
            { }
            return Json(new { success = true, data = current });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult PostCountry(Country dataMod)
        {
            string notif = string.Empty;
            bool isSuccess = true;
            //dataMod.CreatedTime = DateTime.Now;
            //notif = process.PaymentTransEmployeeLoanProcess(ref isSuccess, dataMod, isAll);
            return Json(new { success = isSuccess, message = notif });
        }
    }
}
