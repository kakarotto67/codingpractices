using Enterprise.Service.DAL.EntityFramework;
using Enterprise.Service.Shared.Contracts.DataContracts;

namespace Enterprise.Service.Client.TransformationAspects
{
    internal sealed class OrderTransformationAspect : ITransformationAspect<Order, OrderDto>
    {
        public Order TransformToDatabaseModel(OrderDto dto)
        {
            return new Order
            {
                OrderID = dto.OrderID,
                CustomerID = dto.CustomerID,
                EmployeeID = dto.EmployeeID
            };
        }

        public OrderDto TransformToDtoModel(Order dbModel)
        {
            return new OrderDto
            {
                OrderID = dbModel.OrderID,
                CustomerID = dbModel.CustomerID,
                EmployeeID = dbModel.EmployeeID
            };
        }
    }
}