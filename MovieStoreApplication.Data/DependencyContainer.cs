using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Concrete;
using MovieStoreApplication.Data.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(option => option.UseSqlServer(configuration.GetConnectionString("Default")));


            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            return services;
        }
    }
}
