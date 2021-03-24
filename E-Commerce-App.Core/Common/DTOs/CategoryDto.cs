using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Common.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur")]
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DateOfUpdate { get; set; }
    }
}
