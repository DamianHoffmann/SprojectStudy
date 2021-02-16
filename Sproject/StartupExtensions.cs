
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Sproject
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterApplicationControllers(this IServiceCollection @this)
        {
            @this.AddScoped<CarController, CarController>();
            @this.AddScoped<UserController, UserController>();

            return @this;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection @this)
        {
            @this.AddScoped<ICarRepository, CarRepository>();
            @this.AddScoped<IUserRepository, UserRepository>();
            return @this;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection @this, string ConnectionString)
        {
            @this.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(ConnectionString));

            return @this;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<IApplicationDbContext, ApplicationDbContext>();

       

            return @this;
        }

        public static IServiceCollection RegisterDomainEvents(this IServiceCollection @this)
        {
            return @this;
        }
    }
}
