using System.Collections.Generic;

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
    public class Cart : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}