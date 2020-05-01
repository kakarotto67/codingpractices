﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeWork.TL.ServiceConsumer.EnterpriseServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDto", Namespace="http://schemas.datacontract.org/2004/07/Enterprise.Service.Client.DataService.Dat" +
        "aContracts")]
    [System.SerializableAttribute()]
    public partial class OrderDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> EmployeeIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerID {
            get {
                return this.CustomerIDField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerIDField, value) != true)) {
                    this.CustomerIDField = value;
                    this.RaisePropertyChanged("CustomerID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> EmployeeID {
            get {
                return this.EmployeeIDField;
            }
            set {
                if ((this.EmployeeIDField.Equals(value) != true)) {
                    this.EmployeeIDField = value;
                    this.RaisePropertyChanged("EmployeeID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderID {
            get {
                return this.OrderIDField;
            }
            set {
                if ((this.OrderIDField.Equals(value) != true)) {
                    this.OrderIDField = value;
                    this.RaisePropertyChanged("OrderID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EnterpriseServiceReference.IDataService")]
    public interface IDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetOrderById", ReplyAction="http://tempuri.org/IDataService/GetOrderByIdResponse")]
        HomeWork.TL.ServiceConsumer.EnterpriseServiceReference.OrderDto GetOrderById(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetOrderById", ReplyAction="http://tempuri.org/IDataService/GetOrderByIdResponse")]
        System.Threading.Tasks.Task<HomeWork.TL.ServiceConsumer.EnterpriseServiceReference.OrderDto> GetOrderByIdAsync(int orderId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataServiceChannel : HomeWork.TL.ServiceConsumer.EnterpriseServiceReference.IDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataServiceClient : System.ServiceModel.ClientBase<HomeWork.TL.ServiceConsumer.EnterpriseServiceReference.IDataService>, HomeWork.TL.ServiceConsumer.EnterpriseServiceReference.IDataService {
        
        public DataServiceClient() {
        }
        
        public DataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HomeWork.TL.ServiceConsumer.EnterpriseServiceReference.OrderDto GetOrderById(int orderId) {
            return base.Channel.GetOrderById(orderId);
        }
        
        public System.Threading.Tasks.Task<HomeWork.TL.ServiceConsumer.EnterpriseServiceReference.OrderDto> GetOrderByIdAsync(int orderId) {
            return base.Channel.GetOrderByIdAsync(orderId);
        }
    }
}