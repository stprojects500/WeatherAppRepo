using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWeatherApp.DB;
using MyWeatherApp.Models;
using MyWeatherApp.Services;
using MyWeatherApp.Web.Models;

namespace MyWeatherApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherManager;
        private readonly LogService _logManager;
        public HomeController()
        {
            _weatherManager = new WeatherService();
            _logManager = new LogService();

        }
        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    var result = await _weatherManager.GetAllForecastsAsync();

                    var forecast =
                        result
                        .Where(s => s.City.ToLower() == searchString.ToLower())
                        .FirstOrDefault();

                    if (forecast == null)
                    {
                        forecast =
                            await _weatherManager.WrongDetails(searchString);
                    }

                    return View(forecast);
                }
                return View();
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                await _logManager.LogCustomException(ce);
                return View("Error");
            }
        }

        public async Task<IActionResult> Privacy()
        {
            try
            {
                throw new Exception("Exception logging from method Privacy");
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                await _logManager.LogCustomException(ce);

                return View("Error");
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Exceptions()
        {
            var exceptions =
                await _logManager.GetAllCustomExceptions();
            return View(exceptions);
        }

        public async Task<IActionResult> MyForecast(string searchString)
        {
            try
            {
                var result = await _weatherManager.GetAllForecastsAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    result = result.Where(s => s.City.Contains(searchString));
                }
                return View(result);
            }
            catch (Exception ex)
            {
                CustomException ce = new CustomException(ex);
                await _logManager.LogCustomException(ce);
                return View("Error");
            }

        }
       


    }
}
