using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyWeatherApp.Models
{
    public sealed class WeatherForecast
    {
        public WeatherForecast() { }

        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public double TemperatureC { get; set; }
        public int Humidity { get; set; }
        public double Pressure { get; set; }
        public int Wind { get; set; }
        public string City { get; set; }
    }
}
