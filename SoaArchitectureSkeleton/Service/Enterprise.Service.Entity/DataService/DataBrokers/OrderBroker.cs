using Enterprise.Service.Client.TransformationAspects;
using Enterprise.Service.DAL.EntityFramework;
using Enterprise.Service.DAL.EntityFramework.Repository;
using Enterprise.Service.DAL.Shared.Repository;

namespace Enterprise.Service.Client.DataService.DataBrokers
{
    internal sealed class OrderBroker : IRepositoryInitializer<IRepository<Order>>, IDataBroker
    {
        public IRepository<Order> Repository { get; set; }
        public OrderTransformationAspect TransformationAspect { get; set; } 

        public void Initialize()
        {
            Repository = new OrdersRepository();
            TransformationAspect = new OrderTransformationAspect();
        }
    }
}
