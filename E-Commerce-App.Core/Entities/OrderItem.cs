namespace E_Commerce_App.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Id { get; set; }
        public string SelectedColor { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
