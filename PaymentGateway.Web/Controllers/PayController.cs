using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Api.Entities;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions.Pay;
using PaymentGateway.Web.Exceptions.Refund;
using PaymentGateway.Web.Services;
using PaymentGateway.Web.Utils;
using System;
using System.Collections.Generic;

namespace PaymentGateway.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly IStorageContext _storageContext;

        public PayController(IOperationService operationService, IStorageContext storageContext)
        {
            _operationService = operationService;
            _storageContext = storageContext;
        }

        [HttpGet]
        public IEnumerable<Operation> Get()
        {
            return _storageContext.OperationList;
        }


        [HttpGet("status/{orderId}")]
        public OperationStatus GetStatus(string orderId)
        {
            return _operationService.GetStatus(orderId);
        }

        [HttpPost]
        public PayResult Post([FromBody] PayRequest request)
        {
            CheckHelper.CheckNull(request, nameof(request));
            try
            {
                _operationService.Pay(request.OrderId, request.CardNumber, request.ExpiryMonth, request.ExpiryYear, request.Cvv, request.CardholderName, request.AmountKop);
                
                return PayResult.Ok;
            }
            catch (PayException e)
            {
                return e.ErrorCode;
            }
        }

        [HttpPost("refund")]
        public RefundResult Refund([FromBody] RefundRequest request)
        {
            CheckHelper.CheckNull(request, nameof(request));

            try
            {
                _operationService.Refund(request.OrderId);
                return RefundResult.Ok;
            }
            catch (RefundException e)
            {
                return e.ErrorCode;
            }
        }
    }
}