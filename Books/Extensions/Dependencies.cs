using Books.BLL.Interfaces;
using Books.BLL.Services;
using Books.DAL.Interfaces;
using Books.DAL.Repository;

namespace Books.Extensions
{
    public static class Dependencies
    {
        public static void AddIService(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IOrderService, OrderService>();
        }

        public static void AddIRepository(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
