using System;

namespace ShoppingCart
{
    public class Cheese : IProduct
    {
        private readonly Money _price;
        private readonly DateTime _expiryDate;

        public Cheese(string description, Money price, DateTime expiryDate)
        {
            _price = price;
            _expiryDate = expiryDate;
        }

        public decimal GetPrice()
        {
            var result = DateTime.Compare(_expiryDate, DateTime.Now.Date);
            if (result == 0)
                return _price.Amount/2;
            
            return _price.Amount;
        }
    }
}