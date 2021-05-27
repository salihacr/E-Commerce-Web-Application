namespace E_Commerce_App.Core.Shared.DTOs
{
    public class CartItemDto : BaseDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }

        public string ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int CartId { get; set; }
        public CartDto Cart { get; set; }
    }
}
