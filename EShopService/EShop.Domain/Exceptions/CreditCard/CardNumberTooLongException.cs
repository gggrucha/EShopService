namespace EShop.Domain.Exceptions.CreditCard
{
    public class CardNumberTooLongException : Exception
    {
        public CardNumberTooLongException() : base("Card Number is too long") { }

        public CardNumberTooLongException(Exception innerException) : base("Card Number is too long", innerException) { }
    }
}
