using AutoMapper;
using Books.BLL.Interfaces;
using Books.Common.Entities;
using Books.Common.Models.Books;
using Books.Common.Models.Orders;
using Books.DAL.Interfaces;

namespace Books.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBookService _bookService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IBookService bookService, IOrderRepository orderRepository)
        {
            _bookService = bookService;
            _orderRepository = orderRepository;
        }

        public void Create(List<BookOrder> bookOrders)
        {
            var Order = new Order
            {
                OrderDate = DateTime.Now
            };

            var bookIds = bookOrders.Select(bookOrders => bookOrders.BookId).ToList();

            var orderedBooks = _bookService.GetByIds(bookIds);

            Order.Amount = orderedBooks.Sum(orderedBook => orderedBook.Price * (bookOrders.FirstOrDefault(bookOrder => bookOrder.BookId == orderedBook.Id) ?? new BookOrder()).Quantity);

            Order.OrderItems = new List<OrderItem>();

            Order.OrderItems.AddRange(orderedBooks.Select(orderedBook => new OrderItem
            {
                BookId = orderedBook.Id,
            }));

            _orderRepository.Create(Order);
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            var orders = await _orderRepository.GetAll();

            var ordersDTO = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                Amount = order.Amount,
                OrderedDate = order.OrderDate,
                Books = order.OrderItems.Select(orderItem => orderItem.Book).ToList()
            }).ToList();
            
            return ordersDTO;
        }

        public async Task<OrderDTO> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);

            var orderDTO = ConverOrderToOrderDTO(order);

            return orderDTO;
        }

        public async Task<List<OrderDTO>> GetFiltred(OrderFilter filter)
        {
            var orders = await _orderRepository.GetFiltredOrders(filter);

            var ordersDTO = ConvertOrdersTyOrdersDTO(orders);

            return ordersDTO;
        }

        private static OrderDTO ConverOrderToOrderDTO(Order order)
        {
            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                OrderedDate = order.OrderDate,
                Amount = order.Amount,
                Books = order.OrderItems.Select(orderItem => orderItem.Book).ToList()
            };

            return orderDTO;
        }

        private static List<OrderDTO> ConvertOrdersTyOrdersDTO(List<Order> orders)
        {
            var ordersDTO = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                Amount = order.Amount,
                OrderedDate = order.OrderDate,
                Books = order.OrderItems.Select(orderItem => orderItem.Book).ToList()
            }).ToList();

            return ordersDTO;
        }
    }
}
