using Books.Common.Entities;
using Books.Common.Models.Books;

namespace Books.Common.Models.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime OrderedDate { get; set; }

        public decimal Amount { get; set; }

        public List<Book> Books { get; set; }
    }
}
