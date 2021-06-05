using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class BaseDto
    {
        [Display(Name ="Oluşturma Tarihi")]
        public DateTime? CreationDate { get; set; }
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? DateOfUpdate { get; set; }
        public bool IsActive { get; set; }
    }
}
