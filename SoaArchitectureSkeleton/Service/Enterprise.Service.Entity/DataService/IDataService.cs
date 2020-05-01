using System;
using System.ServiceModel;
using Enterprise.Service.Shared.Contracts.DataContracts;
using Enterprise.Service.Shared.Contracts.DuplexContracts;

namespace Enterprise.Service.Client.DataService
{
    [ServiceContract(Namespace = "https://TlSamples",
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IDataServiceCallback))]
    public interface IDataService
    {
        [OperationContract]
        OrderDto GetOrderById(Int32 orderId);

        [OperationContract(IsOneWay = true)]
        void GetOrderByIdDuplex(Int32 orderId);
    }
}
