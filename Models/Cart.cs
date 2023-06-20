using System;
using System.Collections.Generic;

namespace JengApp.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int ProdId { get; set; }
        public int Cquantity { get; set; }
        public int CmockTotal { get; set; }
        public int CmockStock { get; set; }
    }
}
