using HotCatCafe.BLL.Repositories.Abstracts;
using HotCatCafe.BLL.Repositories.Abstracts.BaseAbstracts;
using HotCatCafe.BLL.Repositories.Concretes;
using HotCatCafe.BLL.Repositories.Concretes.BaseConcretes;
using Microsoft.Extensions.DependencyInjection;

namespace HotCatCafe.IOC.DependencyResolves
{
    public static class RepositoryService
    {

        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ITableSessionService, TableSessionService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
