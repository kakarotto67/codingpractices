using System.Collections.Generic;
using Enterprise.Service.Client.DataService.DataBrokers;

namespace Enterprise.Service.Client.DataService
{
    internal sealed class DataBrokerFacade
    {
        public IEnumerable<IDataBroker> DataBrokers { get; }

        public DataBrokerFacade(IEnumerable<IDataBroker> dataBrokers)
        {
            DataBrokers = dataBrokers;
            InitializeDataBrokers();
        }

        private void InitializeDataBrokers()
        {
            foreach (var dataBroker in DataBrokers)
            {
                dataBroker.Initialize();
            }
        }
    }
}