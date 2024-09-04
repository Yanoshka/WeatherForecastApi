using WeatherForecastApp.OpenWeatherMap_Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace WeatherForecastApp.Repositories
{
    public class WForecastRepository : IWForecastRepository
    {
        public WeatherResponse GetForecast(string city)
        {
                string APP_ID = Configuration.Values.OPEN_WEATHER_APP_ID;
            var client = new RestClient($"https://weather-api138.p.rapidapi.com/weather?city_name={city}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "0d3e90e966msh6c4703b5ad7dd9fp1c5ad1jsn671718005a68");
            request.AddHeader("x-rapidapi-host", "weather-api138.p.rapidapi.com");

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                    return content?.ToObject<WeatherResponse>();
                }
                else
                {
                    return null;
                }
        }
    }
}