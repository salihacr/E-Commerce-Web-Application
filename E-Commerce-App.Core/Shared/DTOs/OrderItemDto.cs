namespace E_Commerce_App.Core.Shared.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string SelectedColor { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
    }
}
