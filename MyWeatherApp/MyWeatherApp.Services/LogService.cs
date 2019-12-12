using Microsoft.EntityFrameworkCore;
using MyWeatherApp.DB;
using MyWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherApp.Services
{
    public class LogService
    {
        private readonly MyWeatherAppDbContext _ctx;
        public LogService()
        {
            _ctx = new MyWeatherAppDbContext();
        }
        public async Task LogCustomException(CustomException ce)
        {
            await _ctx.Exceptions.AddAsync(ce);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomException>> GetAllCustomExceptions()
        {

            List<CustomException> result =
                await _ctx.Exceptions
                    .OrderByDescending(ce => ce.DateCreated)
                    .ToListAsync();

            return result;
        }


    }
}
