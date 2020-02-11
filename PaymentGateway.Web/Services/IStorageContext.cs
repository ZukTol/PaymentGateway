using PaymentGateway.Web.Entities;
using System.Collections.Generic;

namespace PaymentGateway.Web.Services
{
    public interface IStorageContext
    {
        IList<Card> CardList { get; }
        IList<Operation> OperationList { get; }
    }
}
