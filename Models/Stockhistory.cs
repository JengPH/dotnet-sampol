﻿using System;
using System.Collections.Generic;

namespace JengApp.Models
{
    public partial class Stockhistory
    {
        public int AStockId { get; set; }
        public int ProdId { get; set; }
        public int AddedStock { get; set; }
        public string Date { get; set; }
    }
}
