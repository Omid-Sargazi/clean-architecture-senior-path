namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<string> Items { get; set; }
        public decimal TotalAmount { get; set; }

        public Order(List<string> items, decimal totalAmount)
        {
            Id = Guid.NewGuid();
            items = items;
            TotalAmount = totalAmount;
        }
    }
}