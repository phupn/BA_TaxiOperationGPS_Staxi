﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormTestServices.ServicesGEO {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationHeader", Namespace="http://schemas.datacontract.org/2004/07/WCF_ServicesLibrary")]
    [System.SerializableAttribute()]
    public partial class AuthenticationHeader : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassWordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
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
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassWord {
            get {
                return this.PassWordField;
            }
            set {
                if ((object.ReferenceEquals(this.PassWordField, value) != true)) {
                    this.PassWordField = value;
                    this.RaisePropertyChanged("PassWord");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicesGEO.IServicesOnline")]
    public interface IServicesOnline {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetAddressByGeo", ReplyAction="http://tempuri.org/IServicesOnline/GetAddressByGeoResponse")]
        string GetAddressByGeo(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetAddressByGeo", ReplyAction="http://tempuri.org/IServicesOnline/GetAddressByGeoResponse")]
        System.Threading.Tasks.Task<string> GetAddressByGeoAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeobyAddressBA", ReplyAction="http://tempuri.org/IServicesOnline/GetGeobyAddressBAResponse")]
        string GetGeobyAddressBA(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeobyAddressBA", ReplyAction="http://tempuri.org/IServicesOnline/GetGeobyAddressBAResponse")]
        System.Threading.Tasks.Task<string> GetGeobyAddressBAAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeobyAddressBA_HN_First", ReplyAction="http://tempuri.org/IServicesOnline/GetGeobyAddressBA_HN_FirstResponse")]
        string GetGeobyAddressBA_HN_First(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeobyAddressBA_HN_First", ReplyAction="http://tempuri.org/IServicesOnline/GetGeobyAddressBA_HN_FirstResponse")]
        System.Threading.Tasks.Task<string> GetGeobyAddressBA_HN_FirstAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetAddressByGeo_Google", ReplyAction="http://tempuri.org/IServicesOnline/GetAddressByGeo_GoogleResponse")]
        string GetAddressByGeo_Google(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetAddressByGeo_Google", ReplyAction="http://tempuri.org/IServicesOnline/GetAddressByGeo_GoogleResponse")]
        System.Threading.Tasks.Task<string> GetAddressByGeo_GoogleAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeoByAddress_Google", ReplyAction="http://tempuri.org/IServicesOnline/GetGeoByAddress_GoogleResponse")]
        string GetGeoByAddress_Google(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeoByAddress_Google", ReplyAction="http://tempuri.org/IServicesOnline/GetGeoByAddress_GoogleResponse")]
        System.Threading.Tasks.Task<string> GetGeoByAddress_GoogleAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeoByAddress_GoogleV2", ReplyAction="http://tempuri.org/IServicesOnline/GetGeoByAddress_GoogleV2Response")]
        string GetGeoByAddress_GoogleV2(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicesOnline/GetGeoByAddress_GoogleV2", ReplyAction="http://tempuri.org/IServicesOnline/GetGeoByAddress_GoogleV2Response")]
        System.Threading.Tasks.Task<string> GetGeoByAddress_GoogleV2Async(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicesOnlineChannel : FormTestServices.ServicesGEO.IServicesOnline, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicesOnlineClient : System.ServiceModel.ClientBase<FormTestServices.ServicesGEO.IServicesOnline>, FormTestServices.ServicesGEO.IServicesOnline {
        
        public ServicesOnlineClient() {
        }
        
        public ServicesOnlineClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicesOnlineClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicesOnlineClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicesOnlineClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetAddressByGeo(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat) {
            return base.Channel.GetAddressByGeo(authenticate, lng, lat);
        }
        
        public System.Threading.Tasks.Task<string> GetAddressByGeoAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat) {
            return base.Channel.GetAddressByGeoAsync(authenticate, lng, lat);
        }
        
        public string GetGeobyAddressBA(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh) {
            return base.Channel.GetGeobyAddressBA(authenticate, address, TenTinh);
        }
        
        public System.Threading.Tasks.Task<string> GetGeobyAddressBAAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh) {
            return base.Channel.GetGeobyAddressBAAsync(authenticate, address, TenTinh);
        }
        
        public string GetGeobyAddressBA_HN_First(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh) {
            return base.Channel.GetGeobyAddressBA_HN_First(authenticate, address, TenTinh);
        }
        
        public System.Threading.Tasks.Task<string> GetGeobyAddressBA_HN_FirstAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh) {
            return base.Channel.GetGeobyAddressBA_HN_FirstAsync(authenticate, address, TenTinh);
        }
        
        public string GetAddressByGeo_Google(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat) {
            return base.Channel.GetAddressByGeo_Google(authenticate, lng, lat);
        }
        
        public System.Threading.Tasks.Task<string> GetAddressByGeo_GoogleAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, float lng, float lat) {
            return base.Channel.GetAddressByGeo_GoogleAsync(authenticate, lng, lat);
        }
        
        public string GetGeoByAddress_Google(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh) {
            return base.Channel.GetGeoByAddress_Google(authenticate, address, TenTinh);
        }
        
        public System.Threading.Tasks.Task<string> GetGeoByAddress_GoogleAsync(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address, string TenTinh) {
            return base.Channel.GetGeoByAddress_GoogleAsync(authenticate, address, TenTinh);
        }
        
        public string GetGeoByAddress_GoogleV2(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address) {
            return base.Channel.GetGeoByAddress_GoogleV2(authenticate, address);
        }
        
        public System.Threading.Tasks.Task<string> GetGeoByAddress_GoogleV2Async(FormTestServices.ServicesGEO.AuthenticationHeader authenticate, string address) {
            return base.Channel.GetGeoByAddress_GoogleV2Async(authenticate, address);
        }
    }
}
