
using EShop.Domain.Exceptions.CreditCard;
using System.Text.RegularExpressions;

namespace EShop.Application.Services
{
    public interface ICreditCardService
    {
        public Boolean ValidateCardNumber(string cardNumber);

        public string GetCardType(string cardNumber);
    }
}
