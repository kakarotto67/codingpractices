using System;
using HomeWork.TL.ServiceConsumer.EnterpriseServiceReference;

namespace HomeWork.TL.ServiceConsumer
{
    public interface IServiceOperations
    {
        OrderDto GetOrderById(Int32 orderId);
    }
}
