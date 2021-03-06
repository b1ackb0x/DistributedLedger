﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exchange.DispatcherService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/Dispatcher")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DispatcherService.IDispatcher")]
    public interface IDispatcher {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/GetData", ReplyAction="http://tempuri.org/IDispatcher/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/GetData", ReplyAction="http://tempuri.org/IDispatcher/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IDispatcher/GetDataUsingDataContractResponse")]
        Exchange.DispatcherService.CompositeType GetDataUsingDataContract(Exchange.DispatcherService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IDispatcher/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Exchange.DispatcherService.CompositeType> GetDataUsingDataContractAsync(Exchange.DispatcherService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/SetTransaction", ReplyAction="http://tempuri.org/IDispatcher/SetTransactionResponse")]
        void SetTransaction(int senderAccountId, int receiverAccountId, int amt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/SetTransaction", ReplyAction="http://tempuri.org/IDispatcher/SetTransactionResponse")]
        System.Threading.Tasks.Task SetTransactionAsync(int senderAccountId, int receiverAccountId, int amt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/GetBlockChain", ReplyAction="http://tempuri.org/IDispatcher/GetBlockChainResponse")]
        DomainModel.Block[] GetBlockChain();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDispatcher/GetBlockChain", ReplyAction="http://tempuri.org/IDispatcher/GetBlockChainResponse")]
        System.Threading.Tasks.Task<DomainModel.Block[]> GetBlockChainAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDispatcherChannel : Exchange.DispatcherService.IDispatcher, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DispatcherClient : System.ServiceModel.ClientBase<Exchange.DispatcherService.IDispatcher>, Exchange.DispatcherService.IDispatcher {
        
        public DispatcherClient() {
        }
        
        public DispatcherClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DispatcherClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DispatcherClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DispatcherClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public Exchange.DispatcherService.CompositeType GetDataUsingDataContract(Exchange.DispatcherService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Exchange.DispatcherService.CompositeType> GetDataUsingDataContractAsync(Exchange.DispatcherService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public void SetTransaction(int senderAccountId, int receiverAccountId, int amt) {
            base.Channel.SetTransaction(senderAccountId, receiverAccountId, amt);
        }
        
        public System.Threading.Tasks.Task SetTransactionAsync(int senderAccountId, int receiverAccountId, int amt) {
            return base.Channel.SetTransactionAsync(senderAccountId, receiverAccountId, amt);
        }
        
        public DomainModel.Block[] GetBlockChain() {
            return base.Channel.GetBlockChain();
        }
        
        public System.Threading.Tasks.Task<DomainModel.Block[]> GetBlockChainAsync() {
            return base.Channel.GetBlockChainAsync();
        }
    }
}
