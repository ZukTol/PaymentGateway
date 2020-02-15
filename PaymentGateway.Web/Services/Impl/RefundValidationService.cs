using PaymentGateway.Web.Exceptions.Refund;
using System;
using System.Linq;

namespace PaymentGateway.Web.Services.Impl
{
    public class RefundValidationService : IRefundValidationService
    {
        private readonly IStorageContext _storageContext;

        public RefundValidationService(IStorageContext storageContext)
        {
            _storageContext = storageContext;
        }

        public void CheckOrder(Guid orderId)
        {
            CheckOrderExists(orderId);
            CheckOperationStatus(orderId);
        }

        private void CheckOperationStatus(Guid orderId)
        {
            if (!IsDoneStatus(orderId))
            {
                throw new AlreadyRefundException();
            }
        }

        private void CheckOrderExists(Guid orderId)
        {
            if (!IsOrderExixts(orderId))
            {
                throw new OrderNotExistsException();
            }
        }

        private bool IsOrderExixts(Guid orderId)
        {
            return _storageContext.OperationList.Any(o => o.OrderId == orderId);
        }

        private bool IsDoneStatus(Guid orderId)
        {
            var operation = _storageContext.OperationList.First(o => o.OrderId == orderId);
            return operation.Status == Api.Entities.OperationStatus.Done;
        }
    }
}
