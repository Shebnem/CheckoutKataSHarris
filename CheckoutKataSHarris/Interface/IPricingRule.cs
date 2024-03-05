using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataSHarris.Interface
{
    public interface IPricingRule
    {
        char SKU { get; set; }
        int Quantity { get; set; }
        int Value { get; set; }
    }
}
