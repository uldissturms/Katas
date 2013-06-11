using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Product
    {
        public string Sku { get; set; }
        public ushort Price { get; set; }
        public ushort TotalPrice { get; set; }
        public Offer Offer { get; set; }
        public bool IsBilled { get; set; }
    }
}
