using Books.BLL.Interfaces;
using Books.Common.Models.Books;
using Books.Common.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var orders = await _orderService.GetAll();

            return Ok(orders);
        }

        [Route("CreateOrder")]
        [HttpPost]
        public ActionResult CreateOrder(List<BookOrder> bookOrders)
        {
            try
            {
                _orderService.Create(bookOrders);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("GetById")]
        [HttpPost]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var orderDTO = await _orderService.GetById(id);

                return Ok(orderDTO);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("GetFiltred")]
        [HttpPost]
        public async Task<ActionResult> GetFiltred(OrderFilter filter)
        {
            var bookDTO = await _orderService.GetFiltred(filter);

            return Ok(bookDTO);
        }
    }
}
