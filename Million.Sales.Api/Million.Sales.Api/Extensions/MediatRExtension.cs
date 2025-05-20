using Million.Sales.Application.Property.GetAll;

namespace Million.Sales.Api.Extensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection AddMediatRExtension(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllPropertiesQuery).Assembly);
            });

            return services;
        }
    }
}
