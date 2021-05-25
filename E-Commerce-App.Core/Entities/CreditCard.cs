namespace E_Commerce_App.Core.Entities
{
    public class CreditCard : BaseEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public long CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string UserId { get; set; }
    }
}