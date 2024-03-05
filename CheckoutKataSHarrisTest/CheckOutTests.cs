using CheckoutKataSHarris.Interface;
using CheckoutKataSHarris.Model;
using Microsoft.Win32;

namespace CheckoutKataSHarrisTest
{
    [TestClass]
    public class CheckOutTests
    {
        private ICheckOut checkout;

        public CheckOutTests()
        {
            IEnumerable<Product> products = new[]
            {
                new Product{SKU = 'A', Price = 50},
                new Product{SKU = 'B', Price = 30},
                new Product{SKU = 'C', Price = 20},
                new Product{SKU = 'D', Price = 15}
            };

            IEnumerable<PricingRule> discounts = new[]
            {
                new PricingRule{SKU = 'A', Quantity = 3, Value = 20},
                new PricingRule{SKU = 'B', Quantity = 2, Value = 15}
            };

            checkout = new CheckOut(products, discounts);
        }
        [TestMethod]
        public void empty_cart()
        {
            Assert.AreEqual(0, checkout.Scan("").GetTotalPrice());
        }

        [DataRow("A", 50)]
        [DataRow("B", 30)]
        [DataRow("C", 20)]
        [DataRow("D", 15)]
        [DataTestMethod]
        public void one_item_scan(string item, int expected)
        {
            Assert.AreEqual(expected, checkout.Scan(item).GetTotalPrice());
        }
        [DataRow("AA", 100)]
        [DataRow("AB", 80)]
        [DataRow("ABC", 100)]
        [DataRow("ABCCDD", 150)]
        [DataRow("CDBA", 115)]
        [DataTestMethod]
        public void multiple_items_no_discount(string scan, int expected)
        {
            Assert.AreEqual(expected, checkout.Scan(scan).GetTotalPrice());
        }
        [DataRow("AAA", 130)]
        [DataRow("AAAB", 160)]
        [DataRow("AAABB", 175)]
        [DataRow("AAAAA", 230)]
        [DataRow("AAAAAA", 260)]
        [DataRow("AAAAAABB", 305)]
        [DataRow("BB", 45)]
        [DataRow("BAB", 95)]
        [DataRow("BBBB", 90)]
        [DataRow("BBBBACD", 175)]
        [DataTestMethod]
        public void multiple_items_discount_combinations(string scan, int expected)
        {
            Assert.AreEqual(expected, checkout.Scan(scan).GetTotalPrice());
        }
        [DataRow("XYTGHJ", "")]
        [DataRow("ABCDE", "ABCD")]
        [DataRow("AAAA", "AAAA")]
        [DataTestMethod]
        public void multiple_items_invalid_sku_filter(string scan, string expected)
        {
            Assert.AreEqual(expected,new String(checkout.Scan(scan).ScannedProducts));
        }
    }
}