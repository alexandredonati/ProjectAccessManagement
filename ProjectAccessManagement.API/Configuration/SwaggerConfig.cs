using Microsoft.OpenApi.Models;

namespace ProjectAccessManagement.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Project Access Management API",
                    Version = "v1",
                    Description = "API for managing project access and credentials",
                });
            });

            return services;
        }
    }
} 