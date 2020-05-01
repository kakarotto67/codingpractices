using System.ServiceModel;
using Enterprise.Service.Shared.Contracts.DataContracts;

namespace Enterprise.Service.Shared.Contracts.DuplexContracts
{
    public interface IDataServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OrderResult(OrderDto order);
    }
}