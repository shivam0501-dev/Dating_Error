using Dating_API.Data;
using Dating_API.Interface;
using Dating_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Dating_API.Extensions
{
    public static class ApplicationExtensionServices
    {
        public static IServiceCollection AddServicesCollection(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<DataContext>(op => op.UseSqlServer(config.GetConnectionString("Constr")));
            services.AddCors();
            services.AddScoped<ITokenServices,TokenServices>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}