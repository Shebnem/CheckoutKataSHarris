using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataSHarris.Interface
{
    public interface IProduct
    {
        char SKU { get; set; }
        int Price { get; set; }
    }
}
