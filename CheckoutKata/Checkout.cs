using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly IEnumerable<Product> _prices;
        private readonly IList<Product> _bag = new List<Product>();

        public Checkout(IEnumerable<Product> prices)
        {
            _prices = prices;
        }

        public int CalculateTotal()
        {
            if (!_bag.Any())
            {
                return 0;
            }

            foreach (var product in _bag)
            {
                if (product.IsBilled)
                {
                    continue;
                }

                if (QualifiesForOffer(product))
                {
                    ApplyOffer(product);
                    continue;
                }

                product.TotalPrice = product.Price;
            }

            return _bag.Sum(x => x.TotalPrice);
        }

        private void ApplyOffer(Product product)
        {
            product.TotalPrice = product.Offer.Price;
            var productsInOffering = _bag.Where(x => x.Sku == product.Sku && !x.IsBilled)
                .Take(product.Offer.Count);
            foreach (var p in productsInOffering)
            {
                p.IsBilled = true;
            }

        }

        private bool QualifiesForOffer(Product item)
        {
            if (item.Offer == null)
            {
                return false;
            }

            return _bag.Count(x => x.Sku == item.Sku && !x.IsBilled) >= item.Offer.Count;
        }

        public void Scan(string sku)
        {
            var product = _prices.Single(x => x.Sku == sku);
            var item = new Product 
            { 
                Sku = product.Sku, 
                Price = product.Price, 
                Offer = product.Offer 
            };
            _bag.Add(item);
        }
    }
}
