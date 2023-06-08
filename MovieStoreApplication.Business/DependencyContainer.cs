using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreApplication.Business
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<MovieContext>(option => option.UseSqlServer(configuration.GetConnectionString("Default")));

            //kapattıklarını kullanma fikir olsun sadece
            //services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
