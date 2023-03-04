using Application;
using Application.Abstract;
using Application.Security.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concrete;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<ITechnicalServiceRepository, TechnicalServiceRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAccessoryRepository, AccessoryRepository>();
            services.AddScoped<IUserService, UserRepository>();
            services.AddScoped<IAuthService, AuthRepository>();
            services.AddScoped<IProductStockRepository, ProductStockRepository>();
            services.AddScoped<ITokenHelper, JwtHelper>();

 

        }
    }
}
