namespace E_Commerce_App.Core.Entities
{
    public class Campaign : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltTag { get; set; }
        public bool IsHome { get; set; }
    }
}
