using Core.Common.Mappings;
using Core.Data;
using Core.Dreams.Queries;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt => 
            {   
                opt.AddPolicy("CorsPolicy", policy => 
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:5065");
                });
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DreamList.Handler).Assembly));    
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddHttpContextAccessor();
            return services;
        }
    }
}