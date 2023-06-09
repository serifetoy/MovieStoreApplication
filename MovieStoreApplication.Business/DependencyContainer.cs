using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.Concrete;

namespace MovieStoreApplication.Business
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();


            return services;
        }
    }
}
