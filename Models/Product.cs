using System;
using System.Collections.Generic;

namespace JengApp.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        public int Stock { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
    }
}
