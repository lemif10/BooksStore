using Books.Common.Entities;
using Books.Common.Models.Books;
using Books.Common.Models.Orders;

namespace Books.BLL.Interfaces
{
    public interface IOrderService
    {
        void Create(List<BookOrder> bookOrders);

        Task<List<OrderDTO>> GetAll();

        Task<OrderDTO> GetById(int id);

        Task<List<OrderDTO>> GetFiltred(OrderFilter filter);
    }
}
