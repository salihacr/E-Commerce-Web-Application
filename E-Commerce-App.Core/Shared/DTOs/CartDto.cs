namespace E_Commerce_App.Core.Shared.DTOs
{

    public class CartItemDto : BaseDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int CartId { get; set; }
        public CartDto Cart { get; set; }
    }

    public class CartDto : BaseDto
    {

    }
}
