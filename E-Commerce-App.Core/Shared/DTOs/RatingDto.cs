namespace E_Commerce_App.Core.Shared.DTOs
{
    public class RatingDto : BaseDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Point { get; set; }
        public string ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int OrderItemId { get; set; }
        public OrderItemDto OrderItem { get; set; }
    }
}
