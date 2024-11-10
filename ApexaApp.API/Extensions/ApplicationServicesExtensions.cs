using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApexaApp.API.Data;
using ApexaApp.API.Data.Interfaces;
using ApexaApp.API.Data.Repositories;
using ApexaApp.API.Errors;
using ApexaApp.API.Interfaces;
using ApexaApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApexaApp.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            // services.AddDbContext<ApexaContext>(options =>
            // {
            //    options.UseInMemoryDatabase("ApexaDb");
            // });

            services.AddDbContext<ApexaContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<IAdvisorRepository, AdvisorRepository>();
            services.AddScoped<IAdvisorService, AdvisorService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ApiBehaviorOptions>(options => 
            {

                options.InvalidModelStateResponseFactory = ActionContext => 
                {
                    var errors = ActionContext.ModelState
                        .Where(e => e.Value?.Errors.Count > 0)
                        .SelectMany(x => x.Value!.Errors)
                        .Select(x => x.ErrorMessage).ToArray();
                    
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            // services.AddCors(opt => {
            //     opt.AddPolicy("CorsPolicy", policy => {
            //         policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5014","https://localhost:5014");
            //     });
            // });
            

            return services;

        }
    }
}