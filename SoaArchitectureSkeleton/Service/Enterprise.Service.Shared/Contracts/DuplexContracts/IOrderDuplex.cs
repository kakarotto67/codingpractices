using System;
using System.ServiceModel;

namespace Enterprise.Service.Shared.Contracts.DuplexContracts
{
    [ServiceContract(Namespace = "https://TlSamples",
        SessionMode = SessionMode.Required,
        CallbackContract = typeof (IDataServiceCallback))]
    public interface IOrderDuplex
    {
        [OperationContract(IsOneWay = true)]
        void GetOrderByIdDuplex(Int32 orderId);
    }
}