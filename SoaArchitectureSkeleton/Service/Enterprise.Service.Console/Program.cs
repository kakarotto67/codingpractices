using System;
using System.ServiceModel;
using Enterprise.Service.Client;

namespace Enterprise.Service.Console
{
    internal class Program
    {
        public static void Main()
        {
            InitializeService();
        }

        private static void InitializeService()
        {
            ServiceHost enterpriseServiceHost = null;
            try
            {
                // Create service host
                enterpriseServiceHost = new ServiceHost(typeof (EnterpriseService));
                //enterpriseServiceHost.AddServiceEndpoint(typeof(IDataService),
                //    new NetTcpBinding(), "net.tcp://localhost:7171/EnterpriseService");
                //// Check to see if the service host already has a ServiceMetadataBehavior
                //var smb = enterpriseServiceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() ??
                //          new ServiceMetadataBehavior();
                //smb.HttpGetEnabled = true;
                //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                //enterpriseServiceHost.Description.Behaviors.Add(smb);
                //enterpriseServiceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                //    MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                enterpriseServiceHost.Faulted += EnterpriseServiceHostFaulted;
                enterpriseServiceHost.Open();
                System.Console.WriteLine("EnterpriseService is running...");
                System.Console.ReadKey();
            }
            finally
            {
                if (enterpriseServiceHost != null)
                {
                    if (enterpriseServiceHost.State == CommunicationState.Faulted)
                    {
                        enterpriseServiceHost.Abort();
                    }
                    else
                    {
                        enterpriseServiceHost.Close();
                    }
                }
            }
        }

        private static void EnterpriseServiceHostFaulted(object sender, EventArgs e)
        {
            System.Console.WriteLine("The EnterpriseService host has faulted");
        }
    }
}
