namespace ShoppingCart
{
    public class Money
    {
        public decimal Amount { get; private set; }

        public Money(decimal value)
        {
            Amount = value;
        }
    }
}
