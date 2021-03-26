namespace E_Commerce_App.Core.Entities
{
    public class Image : BaseEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        // Relation
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
