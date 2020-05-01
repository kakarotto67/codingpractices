using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Enterprise.Service.Shared.Contracts.FaultContracts;
using HomeWork.TL.Core.Common.IoC;
using HomeWork.TL.Core.Shared.Interfaces.InfrastructureModule.CrossCutting.Logging;
using HomeWork.TL.CoreSite.EnterpriseService;
using HomeWork.TL.CoreSite.ServiceModel;
using HomeWork.TL.ServiceConsumer;
using DependencyInjectionConfiguration = HomeWork.TL.CoreSite.Common.IoC.DependencyInjectionConfiguration;
using ModuleImporter = HomeWork.TL.CoreSite.Common.Composition.ModuleImporter;

namespace HomeWork.TL.CoreSite
{
    public class MvcApplication : HttpApplication
    {
        private ILogger logger;

        protected void Application_Start()
        {
            RegisterModules();
            InitializeDependencyInjection();

            //logger = DependencyInjection.Resolve<ILogger>();

            //logger.LogMessage($"Started at {DateTime.UtcNow}");

            // TODO: try to use it
            //IServiceOperations serviceOperations = new ServiceOperations();
            //var orderDto = serviceOperations.GetOrderById(10254);
            //Debug.WriteLine("Order details: {0} {1} {2}", orderDto.OrderID, orderDto.CustomerID, orderDto.EmployeeID);
            DataServiceCallbackHandler callbackHandler;
            InstanceContext instanceContext;
            DataServiceClient serviceClient = null;
            try
            {
                callbackHandler = new DataServiceCallbackHandler();
                instanceContext = new InstanceContext(callbackHandler);
                serviceClient = new DataServiceClient(instanceContext, "base");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex);
            }
            
            // TODO: Two-way method test
            try
            {
                var orderDto = serviceClient.GetOrderById(-1);
                Debug.WriteLine("Order details: {0} {1} {2}", orderDto.OrderID, orderDto.CustomerID, orderDto.EmployeeID);
            }
            catch (FaultException<IdFault> fe)
            {
                //Debug.WriteLine($"Detail {fe.Detail} Message {fe.Message}, reason {fe.Reason}, action {fe.Action}, code {fe.Code}");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex);
            }
            // TODO: Duplex method test
            try
            {
                serviceClient.GetOrderByIdDuplex(10255);
                //var channels = instanceContext.IncomingChannels;
                //var order = callbackHandler.Order;
                Debug.WriteLine("Done!");
                //IDataServiceCallback callback = new 
            }
            catch (FaultException<IdFault> fe)
            {
                //Debug.WriteLine($"Detail {fe.Detail} Message {fe.Message}, reason {fe.Reason}, action {fe.Action}, code {fe.Code}");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex);
            }

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            //logger.LogMessage($"Closed at {DateTime.UtcNow}");
        }

        private static void RegisterModules()
        {
            var moduleImporter = new ModuleImporter();
            moduleImporter.ImportModules();
        }

        private static void InitializeDependencyInjection()
        {
            var diConfig = new DependencyInjectionConfiguration(DependencyInjection.Container);
            diConfig.Configure();
        }
    }
}
