using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Api.Entities;
using PaymentGateway.Web.Exceptions;
using PaymentGateway.Web.Services;

namespace PaymentGateway.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public PayController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public  ActionResult<OperationResult> Post([FromBody] PayRequest request)
        {
            try
            {
                _operationService.Pay(request.OrderId, request.CardNumber, request.ExpiryMonth, request.ExpiryYear, request.Cvv, request.CardholderName, request.AmountKop);
                
                return OperationResult.Ok;
            }
            catch (PayException e)
            {
                return e.ErrorCode;
            }
        }
    }
}