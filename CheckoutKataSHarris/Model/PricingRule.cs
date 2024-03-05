using CheckoutKataSHarris.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataSHarris.Model
{
    public class PricingRule : IPricingRule
    {
        public char SKU { get ; set ; }
        public int Quantity { get ; set; }
        public int Value { get; set; }
    }
}
