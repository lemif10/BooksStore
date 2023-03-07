namespace Books.Common.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Amount { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
