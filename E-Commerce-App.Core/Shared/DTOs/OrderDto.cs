﻿using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class OrderDto : BaseDto
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderState OrderState { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
