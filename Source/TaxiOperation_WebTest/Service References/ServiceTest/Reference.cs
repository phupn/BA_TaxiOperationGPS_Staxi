﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxiOperation_WebTest.ServiceTest {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/TaxiOperation_ServiceTest")]
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceTest.ITaxiOperation")]
    public interface ITaxiOperation {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaxiOperation/GetData", ReplyAction="http://tempuri.org/ITaxiOperation/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaxiOperation/GetData", ReplyAction="http://tempuri.org/ITaxiOperation/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaxiOperation/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ITaxiOperation/GetDataUsingDataContractResponse")]
        TaxiOperation_WebTest.ServiceTest.CompositeType GetDataUsingDataContract(TaxiOperation_WebTest.ServiceTest.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaxiOperation/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ITaxiOperation/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<TaxiOperation_WebTest.ServiceTest.CompositeType> GetDataUsingDataContractAsync(TaxiOperation_WebTest.ServiceTest.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaxiOperation/GetDomain", ReplyAction="http://tempuri.org/ITaxiOperation/GetDomainResponse")]
        string GetDomain();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaxiOperation/GetDomain", ReplyAction="http://tempuri.org/ITaxiOperation/GetDomainResponse")]
        System.Threading.Tasks.Task<string> GetDomainAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITaxiOperationChannel : TaxiOperation_WebTest.ServiceTest.ITaxiOperation, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaxiOperationClient : System.ServiceModel.ClientBase<TaxiOperation_WebTest.ServiceTest.ITaxiOperation>, TaxiOperation_WebTest.ServiceTest.ITaxiOperation {
        
        public TaxiOperationClient() {
        }
        
        public TaxiOperationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaxiOperationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaxiOperationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaxiOperationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public TaxiOperation_WebTest.ServiceTest.CompositeType GetDataUsingDataContract(TaxiOperation_WebTest.ServiceTest.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<TaxiOperation_WebTest.ServiceTest.CompositeType> GetDataUsingDataContractAsync(TaxiOperation_WebTest.ServiceTest.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string GetDomain() {
            return base.Channel.GetDomain();
        }
        
        public System.Threading.Tasks.Task<string> GetDomainAsync() {
            return base.Channel.GetDomainAsync();
        }
    }
}
