using PaymentGateway.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Web.Exceptions.Pay
{
    public class OrderIdEmptyException : PayException
    {
        public override PayResult ErrorCode => PayResult.OrderIdEmpty;
    }
}
