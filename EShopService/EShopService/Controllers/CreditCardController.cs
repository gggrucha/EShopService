using EShop.Application.Services;
using EShop.Domain.Exceptions.CreditCard;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        protected ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        public IActionResult Get(string cardNumber)
        {
            try
            {
                _creditCardService.ValidateCardNumber(cardNumber);
                return Ok(new { cardProvider = _creditCardService.GetCardType(cardNumber) });
            }
            catch(CardNumberTooLongException ex)
            {
                return StatusCode((int)HttpStatusCode.RequestUriTooLong, new { error = ex.Message, code = (int)HttpStatusCode.RequestUriTooLong });
            }
            catch (CardNumberTooShortException ex)
            {
                return BadRequest(new { error = ex.Message, code = (int)HttpStatusCode.BadRequest });
            }
            catch (CardNumberInvalidException ex)
            {
                return BadRequest(new { error = ex.Message, code = (int)HttpStatusCode.BadRequest });
            }
        }
    }
}
