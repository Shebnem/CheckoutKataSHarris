using CheckoutKataSHarris.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataSHarris.Model
{
    public class Product : IProduct
    {
        public char SKU { get; set ; }
        public int Price { get; set; }
    }
}

