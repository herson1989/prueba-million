using Million.Sales.Domain.Interfaces;
using Million.Sales.Domain.Settings;
using Million.Sales.Domain.UseCases;
using Million.Sales.Infrastructure.Repositories;

namespace Million.Sales.Api.Extensions
{
    public static class DependenciesExtension
    {
        public static IServiceCollection AddDependenciesExtension(this IServiceCollection services, IConfiguration configuration)
        {
            //CaseUses
            services.AddTransient<IGetAllPropertiesUseCase, GetAllPropertiesUseCase>();
            services.AddTransient<IGetImagesByPropertyIdUseCase, GetImagesByPropertyIdUseCase>();
            services.AddTransient<IGetOwnerByPropertyIdUseCase, GetOwnerByPropertyIdUseCase>();

            //Repositories
            services.AddTransient<ISalesRepository, SalesRepository>();

            //Settings
            services.Configure<MongoSetting>(configuration.GetSection("MongoSetting"));

            return services;
        }
    }
}
