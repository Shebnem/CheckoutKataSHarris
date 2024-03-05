using CheckoutKataSHarris.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKataSHarris.Model
{
    public class CheckOut : ICheckOut
    {
        private readonly IEnumerable<IProduct> productPrices;
        private readonly IEnumerable<IPricingRule> pricingRules;
        public char[] scannedProducts;

        char[] ICheckOut.ScannedProducts { get { return scannedProducts; } }
        public CheckOut(IEnumerable<IProduct> products, IEnumerable<IPricingRule> rules)
        {
            this.productPrices = products;
            this.pricingRules = rules;
            scannedProducts = new char[] { };
        }
        public ICheckOut Scan(string scan)
        {
            if (!String.IsNullOrEmpty(scan))
            {
                scannedProducts = scan
                    .ToCharArray()
                    .Where(scannedSKU => productPrices.Any(product => product.SKU == scannedSKU))
                    .ToArray();
            }
            return this;
        }

        public int GetTotalPrice()
        {
            int total = 0;
            int totalDiscount = 0;
            total = scannedProducts.Sum(item => PriceFor(item));
            totalDiscount = pricingRules.Sum(discount => CalculateDiscount(discount, scannedProducts));
            return total - totalDiscount;
        }
        private int PriceFor(char sku)
        {
            return productPrices.Single(p => p.SKU == sku).Price;
        }
        private int CalculateDiscount(IPricingRule rule, char[] cart)
        {
            int itemCount = cart.Count(item => item == rule.SKU);
            return (itemCount / rule.Quantity) * rule.Value;
        }
    }
}
