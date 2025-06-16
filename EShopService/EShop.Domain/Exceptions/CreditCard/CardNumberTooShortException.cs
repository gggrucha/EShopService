namespace EShop.Domain.Exceptions.CreditCard
{
    public class CardNumberTooShortException : Exception
    {
        public CardNumberTooShortException() : base("Card Number is too short") { }

        public CardNumberTooShortException(Exception innerException) : base("Card Number is too short", innerException) { }
    }
}
