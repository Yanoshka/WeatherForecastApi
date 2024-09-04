using System.ComponentModel.DataAnnotations;

namespace WeatherForecastApp.Models
{
    public class City
    {
        [Display(Name = "City Name:")]
        public string Name { get; set; }

        [Display(Name = "Temp:")]
        public float Temperature { get; set; }

        [Display(Name = "Feels Like:")]
        public float FeelsLike { get; set; }

        [Display(Name = "Minimum Temperature:")]
        public float TempMin { get; set; }

        [Display(Name = "Maximum Temperature:")]
        public float TempMax { get; set; }

        [Display(Name = "Pressure:")]
        public int Pressure { get; set; }

        [Display(Name = "Humidity:")]
        public int Humidity { get; set; }

        [Display(Name = "Weather:")]
        public string WeatherDescription { get; set; }

        [Display(Name = "Wind Speed:")]
        public float WindSpeed { get; set; }

        [Display(Name = "Wind Degree:")]
        public int WindDegree { get; set; }

        [Display(Name = "Cloudiness:")]
        public int Cloudiness { get; set; }

        [Display(Name = "Country:")]
        public string Country { get; set; }

        [Display(Name = "Sunrise:")]
        public string Sunrise { get; set; }

        [Display(Name = "Sunset:")]
        public string Sunset { get; set; }
    }

}

