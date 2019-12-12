using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyWeatherApp.Models
{
    public sealed class MyWeather
    {
        public MyWeather() { }

        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public string City { get; set; }


    }
}
