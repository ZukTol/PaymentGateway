using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Services;

namespace PaymentGateway.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IStorageContext _storageContext;
        public CardController(IStorageContext storageContext)
        {
            _storageContext = storageContext;
        }

        [HttpGet]
        public IEnumerable<Card> Get()
        {
            return _storageContext.CardList;
        }
    }
}