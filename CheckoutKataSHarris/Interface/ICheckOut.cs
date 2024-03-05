using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataSHarris.Interface
{
    public interface ICheckOut
    {
        ICheckOut Scan(String scan);
        int GetTotalPrice();
        char[] ScannedProducts { get; }
    }
}
