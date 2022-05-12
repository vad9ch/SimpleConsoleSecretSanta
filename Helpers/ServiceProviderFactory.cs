using BL;
using DL;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Helpers
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection()
                .AddDbContext<GiftContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TGlobal;Trusted_Connection=True;MultipleActiveResultSets=true"))
                .AddTransient<IGiftCalculator, GiftCalculator>()
                .BuildServiceProvider();

            return services;
        }

    }
}
