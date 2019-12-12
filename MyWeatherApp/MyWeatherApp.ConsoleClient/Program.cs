using MyWeatherApp.DB;
using MyWeatherApp.Models;
using System;
using System.Collections.Generic;

namespace MyWeatherApp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var myforecasts = GenerateForecast();
            PrintForecast(myforecasts);
            InsertForecast(myforecasts);
        }

        private static List<MyWeather> GenerateForecast()
        {
            var weeklyForecast = new List<MyWeather>();
            var rng = new Random();         

            string[] Cities =
              new[]
              {
                    "Vidin",
                    "Plovdiv",
                    "Sliven",
                    "Burgas",
                    "Stara Zagora",
                    "Asenovgrad",
                    "Varna",
                    "Sofia",
                    "Blagoevgrad",
                    "Silistra",
              };

            for (int i = 0; i < 20; i++)
            {
                var forecast = new MyWeather
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = DateTime.Now.AddDays(i),
                    MaxTemp = rng.Next(1, 35),
                    MinTemp = rng.Next(-10,20),
                    City = Cities[rng.Next(Cities.Length)]
                };
                weeklyForecast.Add(forecast);
            };
            return weeklyForecast;
        }

        private static void PrintForecast(List<MyWeather> myforecasts)
        {
            Console.WriteLine(new string('-', 97));
            Console.WriteLine($"| {"MyWeatherApp",53} {" ", 40}|");
            Console.WriteLine(new string('-', 97));
            Console.WriteLine($"| {"ID",-36} | {"Date",-13} | {"MaxTemp",-12} | {"MinTemp",-8} | {"City",-13}|");
            Console.WriteLine(new string('-', 97));
            for (int i = 0; i < myforecasts.Count; i++)
            {
                Console.WriteLine(
                    $"| {myforecasts[i].Id,-10} | " +
                    $"{myforecasts[i].Date.ToShortDateString(),-13} | " +
                    $"{myforecasts[i].MaxTemp + " °C",-12:N2} | " +
                    $"{myforecasts[i].MinTemp + " °C",-8} | " +
                    $"{myforecasts[i].City,-12} |"
                );
            }
            Console.WriteLine(new string('-', 97));
        }
        
        private static void InsertForecast(List<MyWeather> myforecasts)
        {
            try
            {
                //throw new Exception("WTF?!??! Testing exception logging!!!");
                var ctx = new MyWeatherAppDbContext();

                for (int i = 0; i < myforecasts.Count; i++)
                {
                    ctx.Weather.Add(myforecasts[i]);
                }

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                Console.WriteLine(ce.ClientErrorMessage);
                var ctx = new MyWeatherAppDbContext();
                ctx.Exceptions.Add(ce);
                ctx.SaveChanges();
            }
        }
        
    }
}
