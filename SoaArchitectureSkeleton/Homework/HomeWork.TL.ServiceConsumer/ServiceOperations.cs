using System;
using HomeWork.TL.ServiceConsumer.EnterpriseServiceReference;

namespace HomeWork.TL.ServiceConsumer
{
    public class ServiceOperations : IServiceOperations
    {
        private readonly DataServiceClient serviceClient;

        public ServiceOperations()
        {
            serviceClient = new DataServiceClient();
        }

        public OrderDto GetOrderById(Int32 orderId)
        {
            return serviceClient.GetOrderById(orderId);
        }
    }
}
