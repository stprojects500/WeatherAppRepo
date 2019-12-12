using Microsoft.EntityFrameworkCore;
using MyWeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyWeatherApp.DB
{
    public class MyWeatherAppDbContext : DbContext
    {
        //public DbSet<WeatherForecast> Forecasts { get; set; }
        public DbSet<WeatherForecast> Forecasts { get; set; }
        public DbSet<CustomException> Exceptions { get; set; }
        public DbSet<MyWeather> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-JFQU4F2\SQLEXPRESS;Database=MyWeatherApp-DB;Integrated Security=True"
            );
        }
    }
}
