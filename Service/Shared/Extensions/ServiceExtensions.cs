using Domain.Repository;
using Domain.Services;
using Infra;
using Microsoft.Extensions.DependencyInjection;
using Services.Payments;

namespace Services.Shared.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRandomService, RandomService>();
            services.AddScoped<IRandomRepository, RandomRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IPaymentStrategy, PixPayment>();
            services.AddScoped<IPaymentStrategy, CredCardPayment>();
            services.AddScoped<IPaymentStrategy, PayPalPayment>();

            services.AddScoped<PaymentProcessor>();

            return services;
        }
    }
}
