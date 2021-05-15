namespace E_Commerce_App.Core.Shared.DTOs
{
    public class ImageDto : BaseDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string ProductId { get; set; }
    }
}
