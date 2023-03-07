using Books.Common.Entities;
using Books.Common.Models.Books;
using Books.Common.Models.Orders;

namespace Books.DAL.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);

        Task<List<Order>> GetAll();

        Task<Order> GetById(int id);

        Task<List<Order>> GetFiltredOrders(OrderFilter filter);
    }
}
