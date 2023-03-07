namespace Books.Common.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
