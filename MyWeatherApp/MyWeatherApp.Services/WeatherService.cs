using Microsoft.EntityFrameworkCore;
using MyWeatherApp.DB;
using MyWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherApp.Services
{
    public class WeatherService
    {
        private readonly MyWeatherAppDbContext _ctx;

        public WeatherService()
        {
            _ctx = new MyWeatherAppDbContext();
        }
        
        public async Task LogForecast(MyWeather myWeather)
        {
            await _ctx.Weather.AddAsync(myWeather);
        }
        public async Task<IEnumerable<MyWeather>> GetAllForecastsAsync()
        {
            List<MyWeather> result =
                await _ctx.Weather.ToListAsync();

            return result;
        }

        public async Task<MyWeather> WrongDetails(string searchString)
        {
            try
            {
                throw new NotImplementedException("There is no such city in the database.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task LogDetails(MyWeather id)
        {
            await _ctx.Weather.AddAsync(id);
            await _ctx.SaveChangesAsync();
        }
        public async Task FirstOrDef(MyWeather id)
        {
            await _ctx.Weather.FirstOrDefaultAsync();
        }






    }
}
