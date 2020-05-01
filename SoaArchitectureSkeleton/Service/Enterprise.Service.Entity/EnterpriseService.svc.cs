using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Enterprise.Service.Client.DataService;
using Enterprise.Service.Client.DataService.DataBrokers;
using Enterprise.Service.Shared.Contracts.DataContracts;
using Enterprise.Service.Shared.Contracts.DuplexContracts;
using Enterprise.Service.Shared.Contracts.FaultContracts;

namespace Enterprise.Service.Client
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class EnterpriseService : IDataService
    {
        private DataBrokerFacade dataBrokerFacade;
        private readonly IDataServiceCallback callback;

        public EnterpriseService()
        {
            Initialize();
            callback = OperationContext.Current.GetCallbackChannel<IDataServiceCallback>();
        }

        public OrderDto GetOrderById(Int32 orderId)
        {
            if (orderId < 0)
            {
                var idFault = new IdFault
                {
                    Operation = "GetOrderById",
                    ProblemType = "ID is less than zero"    
                };
                throw new FaultException<IdFault>(idFault);
            }
            var orderBroker = dataBrokerFacade.DataBrokers.OfType<OrderBroker>().Single();
            return orderBroker.TransformationAspect.TransformToDtoModel(orderBroker.Repository.GetEntityById(orderId));
        }

        public void GetOrderByIdDuplex(Int32 orderId)
        {
            // Get the order using two-way method
            var order = GetOrderById(orderId);
            // Set the order into callback result
            callback.OrderResult(order);
        }

        private void Initialize()
        {
            dataBrokerFacade = new DataBrokerFacade(new List<IDataBroker>
            {
                new OrderBroker()
            });
        }
    }
}
