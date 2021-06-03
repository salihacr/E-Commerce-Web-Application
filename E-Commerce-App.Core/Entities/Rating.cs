namespace E_Commerce_App.Core.Entities
{
    public class Rating : BaseEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Point { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
