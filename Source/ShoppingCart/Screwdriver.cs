namespace ShoppingCart
{
    public class Screwdriver : IProduct
    {
        private readonly Money _price;

        public Screwdriver(string description, Money price)
        {
            _price = price;
        }

        public decimal GetPrice()
        {
            return _price.Amount;
        }
    }
}