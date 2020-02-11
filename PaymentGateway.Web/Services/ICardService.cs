using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Web.Services
{
    public interface ICardService
    {
        Guid GetCard(string cardNumber, int expiryMonth, int expiryYear, string cardholderName);
        void Increase(Guid cardId, long amountKop);
        void Decrease(Guid cardId, long amountKop);
    }
}
