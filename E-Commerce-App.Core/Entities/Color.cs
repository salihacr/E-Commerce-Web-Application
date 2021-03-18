using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_App.Core.Entities
{
    public class Color : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
