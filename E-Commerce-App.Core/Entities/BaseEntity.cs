using System;

namespace E_Commerce_App.Core.Entities
{
    public class BaseEntity
    {
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public DateTime? DateOfUpdate { get; set; }
        public DateTime? DateOfDelete { get; set; }
        public bool IsActive { get; set; }
    }
}
