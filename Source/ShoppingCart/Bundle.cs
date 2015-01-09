using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class Bundle : IProduct
    {
        private readonly IList<IProduct> _products;
        
        public Bundle(IList<IProduct> products)
        {
            _products = products;
        }

        public decimal GetPrice()
        {
            var amount = _products.Sum(product => product.GetPrice());

            return amount - (amount/10);
        }
    }
}
