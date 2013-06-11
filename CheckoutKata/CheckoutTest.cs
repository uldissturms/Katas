using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit;
using NUnit.Framework;

namespace CheckoutKata
{
    [TestFixture]
    public class CheckoutTest
    {
        private IEnumerable<Product> GetPrices()
        {
            var prices = new List<Product> 
            {
                new Product { Sku = "A", Price = 50, Offer = new Offer { Count = 3, Price = 130 } },
                new Product { Sku = "B", Price = 30, Offer = new Offer { Count = 2, Price = 45 } },
                new Product { Sku = "C", Price = 20 },
                new Product { Sku = "D", Price = 15 }
            };

            return prices;
        }

        [Test]
        public void CalculateTotal_NoItems_ReturnsZero()
        {
            var checkout = new Checkout(null);

            var total = checkout.CalculateTotal();

            total.Should().Be(0);
        }

        [Test]
        public void CalculateTotal_OneItem_ReturnsItemsValue()
        {
            var prices = GetPrices();

            var checkout = new Checkout(prices);
            checkout.Scan("A");

            var total = checkout.CalculateTotal();

            total.Should().Be(50);
        }

        [Test]
        public void CalculateTotal_TwoItems_ReturnsSumOfTwoItems() 
        {
            var prices = GetPrices();

            var checkout = new Checkout(prices);
            checkout.Scan("A");
            checkout.Scan("B");

            var total = checkout.CalculateTotal();

            total.Should().Be(80);
        }

        [Test]
        public void CalulateTotal_OneItemFromEachProduct_ReturnsSum()
        {
            var prices = GetPrices();

            var checkout = new Checkout(prices);
            checkout.Scan("C");
            checkout.Scan("D");
            checkout.Scan("B");
            checkout.Scan("A");

            var total = checkout.CalculateTotal();

            total.Should().Be(115);
        }

        [Test]
        public void CalulateTotal_ItemsThatDontQualifyForOffer_ShouldBeSummed()
        {
            var prices = GetPrices();

            var checkout = new Checkout(prices);
            checkout.Scan("A");
            checkout.Scan("A");

            var total = checkout.CalculateTotal();

            total.Should().Be(100);
        }

        [Test]
        public void CalulateTotal_ItemsThatQualifyForOffer_OfferShouldBeApplied()
        {
            var prices = GetPrices();

            var checkout = new Checkout(prices);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            var total = checkout.CalculateTotal();

            total.Should().Be(130);
        }

        [Test]
        public void CalulateTotal_ItemsThatQualifyForOfferOfDifferentKinds_OfferShouldBeAppliedToBoth()
        {
            var prices = GetPrices();

            var checkout = new Checkout(prices);
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");

            var total = checkout.CalculateTotal();

            total.Should().Be(175);
        }
    }
}
