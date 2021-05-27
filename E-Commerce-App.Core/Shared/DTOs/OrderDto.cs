using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class OrderDto : BaseDto
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(2, ErrorMessage = "Bu alan en az 2 harften oluşabilir.")]
        [MaxLength(50, ErrorMessage = "Bu alan en fazla 50 harften oluşabilir.")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(2, ErrorMessage = "Bu alan en az 2 harften oluşabilir.")]
        [MaxLength(50, ErrorMessage = "Bu alan en fazla 50 harften oluşabilir.")]
        public string LastName { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(10, ErrorMessage = "Bu alan en az 10 harften oluşabilir.")]
        [MaxLength(120, ErrorMessage = "Bu alan en fazla 120 harften oluşabilir.")]
        public string Address { get; set; }
        [Display(Name = "İl")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string City { get; set; }
        public string District { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumOrderState OrderState { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string SelectedColor { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
    }
}
