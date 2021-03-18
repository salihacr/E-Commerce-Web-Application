using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_App.Core.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
    public enum EnumPaymentType
    {
        CreditCard,
        Eft
    }
    public enum EnumOrderState
    {
        Waiting,
        Unpaid,
        Completed
    }
}
