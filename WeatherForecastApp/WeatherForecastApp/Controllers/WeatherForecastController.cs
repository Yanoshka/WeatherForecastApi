using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecastApp.Models;
using WeatherForecastApp.OpenWeatherMap_Model;
using WeatherForecastApp.Repositories;

namespace WeatherForecastApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWForecastRepository _WForecastRepository;
        public WeatherForecastController(IWForecastRepository WForecastRepository)
        {
            _WForecastRepository = WForecastRepository;
        }

        [HttpGet]
        public IActionResult SearchByCity()
        {
            var viewModel = new SearchByCity();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SearchByCity(SearchByCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = model.CityName });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
            City viewModel = new City();
            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Temperature =(int)Math.Round(weatherResponse.Main.Temp - 273.15f);
                viewModel.FeelsLike = (int)Math.Round(weatherResponse.Main.Feels_Like - 273.15f);
                viewModel.TempMin = (int)Math.Round(weatherResponse.Main.Temp_Min - 273.15f);
                viewModel.TempMax = (int)Math.Round(weatherResponse.Main.Temp_Max - 273.15f);
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.WeatherDescription = weatherResponse.Weather[0].Main;
                viewModel.WindSpeed = weatherResponse.Wind.Speed;
                viewModel.WindDegree = weatherResponse.Wind.Deg;
                viewModel.Cloudiness = weatherResponse.Clouds.All;
                viewModel.Country = weatherResponse.Sys.Country;

                DateTimeOffset sunriseDateTime = DateTimeOffset.FromUnixTimeSeconds(weatherResponse.Sys.Sunrise).ToOffset(TimeSpan.FromSeconds(weatherResponse.Timezone)); //latest change
                DateTimeOffset sunsetDateTime = DateTimeOffset.FromUnixTimeSeconds(weatherResponse.Sys.Sunset).ToOffset(TimeSpan.FromSeconds(weatherResponse.Timezone));


                viewModel.Sunrise = sunriseDateTime.ToString("HH:mm:ss");
                viewModel.Sunset = sunsetDateTime.ToString("HH:mm:ss");
            }
            return View(viewModel);
        }

    }
}

