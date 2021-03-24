using System;

namespace E_Commerce_App.Core.Common.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DateOfUpdate { get; set; }
    }
}
