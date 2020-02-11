using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Api.Entities;

namespace PaymentGateway.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        public  ActionResult<OperationResult> Post([FromBody] PayRequest request)
        {
            return new ActionResult<OperationResult>(OperationResult.Ok);
        }
    }
}