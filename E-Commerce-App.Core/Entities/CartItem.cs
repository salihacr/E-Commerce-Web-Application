using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_App.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CardId { get; set; }
        public Cart Cart { get; set; }

    }
}
