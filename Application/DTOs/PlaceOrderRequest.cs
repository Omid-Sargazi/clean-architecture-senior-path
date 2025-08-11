namespace Application.DTOs
{
    public class PlaceOrderRequest
    {
        public List<string> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}