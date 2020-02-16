using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Client.Services
{
    interface IPaymentMenuService
    {
        Task RunMenu();
    }
}
