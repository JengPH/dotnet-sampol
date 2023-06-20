using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JengApp.ViewModel
{
    public class orderinfo
    {
          public string productName { get; set; }
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float ProductTotal { get; set; }
    }
}