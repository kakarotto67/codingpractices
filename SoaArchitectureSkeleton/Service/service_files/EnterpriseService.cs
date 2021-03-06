﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Enterprise.Service.Client.DataService.DataContracts
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDto", Namespace="http://schemas.datacontract.org/2004/07/Enterprise.Service.Client.DataService.Dat" +
        "aContracts")]
    public partial class OrderDto : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CustomerIDField;
        
        private System.Nullable<int> EmployeeIDField;
        
        private int OrderIDField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerID
        {
            get
            {
                return this.CustomerIDField;
            }
            set
            {
                this.CustomerIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> EmployeeID
        {
            get
            {
                return this.EmployeeIDField;
            }
            set
            {
                this.EmployeeIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderID
        {
            get
            {
                return this.OrderIDField;
            }
            set
            {
                this.OrderIDField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IDataService")]
public interface IDataService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetOrderById", ReplyAction="http://tempuri.org/IDataService/GetOrderByIdResponse")]
    Enterprise.Service.Client.DataService.DataContracts.OrderDto GetOrderById(int orderId);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetOrderById", ReplyAction="http://tempuri.org/IDataService/GetOrderByIdResponse")]
    System.Threading.Tasks.Task<Enterprise.Service.Client.DataService.DataContracts.OrderDto> GetOrderByIdAsync(int orderId);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IDataServiceChannel : IDataService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class DataServiceClient : System.ServiceModel.ClientBase<IDataService>, IDataService
{
    
    public DataServiceClient()
    {
    }
    
    public DataServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public DataServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public Enterprise.Service.Client.DataService.DataContracts.OrderDto GetOrderById(int orderId)
    {
        return base.Channel.GetOrderById(orderId);
    }
    
    public System.Threading.Tasks.Task<Enterprise.Service.Client.DataService.DataContracts.OrderDto> GetOrderByIdAsync(int orderId)
    {
        return base.Channel.GetOrderByIdAsync(orderId);
    }
}
