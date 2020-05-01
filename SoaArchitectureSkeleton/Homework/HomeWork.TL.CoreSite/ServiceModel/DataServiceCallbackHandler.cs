using System.Diagnostics;
using Enterprise.Service.Shared.Contracts.DataContracts;
using HomeWork.TL.CoreSite.EnterpriseService;

namespace HomeWork.TL.CoreSite.ServiceModel
{
    public class DataServiceCallbackHandler : IDataServiceCallback
    {
        public OrderDto Order { get; private set; }

        public void OrderResult(OrderDto order)
        {
            Order = order;
            Debug.WriteLine($"Result: Order[ OrderID={order.OrderID}, CustomerID={order.CustomerID}, EmployeeID={order.EmployeeID}]");
        }
    }
}