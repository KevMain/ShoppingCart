using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        public IList<IProduct> Products;

        public ShoppingCart()
        {
            Products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }

        public decimal GetTotalPrice()
        {
            return Products.Sum(product => product.GetPrice());
        }
    }
}