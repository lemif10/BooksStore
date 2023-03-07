using Books.Common.Entities;
using Books.Common.Models.Orders;
using Books.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _applicationContext;

        public OrderRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Create(Order order)
        {
            _applicationContext.Orders.Add(order);

            _applicationContext.SaveChanges();
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await _applicationContext.Orders.Include("OrderItems.Book").ToListAsync();

            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _applicationContext.Orders.Include("OrderItems.Book").FirstOrDefaultAsync(order => order.Id == id) ?? new Order();

            return order;
        }

        public async Task<List<Order>> GetFiltredOrders(OrderFilter filter)
        {
            var query = _applicationContext.Orders.AsQueryable();

            if (filter.Year is not 0)
            {
                query = query.Where(book => book.OrderDate.Year == filter.Year);
            }

            if (filter.Month is not 0)
            {
                query = query.Where(book => book.OrderDate.Month == filter.Month);
            }

            if (filter.Day is not 0)
            {
                query = query.Where(book => book.OrderDate.Day == filter.Day);
            }

            if (filter.Hour is not -1)
            {
                query = query.Where(book => book.OrderDate.Hour == filter.Hour);
            }

            if (filter.Minute is not -1)
            {
                query = query.Where(book => book.OrderDate.Minute == filter.Minute);
            }

            var orders = await query.Include("OrderItems.Book").ToListAsync();

            return orders;
        }
    }
}
