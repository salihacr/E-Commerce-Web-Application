namespace E_Commerce_App.Core.Entities
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string FullAddress { get; set; }
        public string UserId { get; set; }
    }
}