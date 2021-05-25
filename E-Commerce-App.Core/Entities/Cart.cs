using System.Collections.Generic;

namespace E_Commerce_App.Core.Entities
{
    public class Cart : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}