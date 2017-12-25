﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormTestServices.Server_BookingTaxi_ThanhCong {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap")]
    public interface TaxiOperation_ServicesSoap {
        
        // CODEGEN: Generating message contract since message BookingTaxiRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BookingTaxi", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiResponse BookingTaxi(FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/BookingTaxi", ReplyAction="*")]
        System.Threading.Tasks.Task<FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiResponse> BookingTaxiAsync(FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Authentication : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string userNameField;
        
        private string passwordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BookingTaxi", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class BookingTaxiRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public FormTestServices.Server_BookingTaxi_ThanhCong.Authentication Authentication;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string CustName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Phone;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string Addr;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string VehType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public int Qty;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        public System.DateTime Time;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=6)]
        public string GhiChu;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=7)]
        public int brand;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=8)]
        public short src;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=9)]
        public string dmn;
        
        public BookingTaxiRequest() {
        }
        
        public BookingTaxiRequest(FormTestServices.Server_BookingTaxi_ThanhCong.Authentication Authentication, string CustName, string Phone, string Addr, string VehType, int Qty, System.DateTime Time, string GhiChu, int brand, short src, string dmn) {
            this.Authentication = Authentication;
            this.CustName = CustName;
            this.Phone = Phone;
            this.Addr = Addr;
            this.VehType = VehType;
            this.Qty = Qty;
            this.Time = Time;
            this.GhiChu = GhiChu;
            this.brand = brand;
            this.src = src;
            this.dmn = dmn;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BookingTaxiResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class BookingTaxiResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string BookingTaxiResult;
        
        public BookingTaxiResponse() {
        }
        
        public BookingTaxiResponse(string BookingTaxiResult) {
            this.BookingTaxiResult = BookingTaxiResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TaxiOperation_ServicesSoapChannel : FormTestServices.Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaxiOperation_ServicesSoapClient : System.ServiceModel.ClientBase<FormTestServices.Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap>, FormTestServices.Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap {
        
        public TaxiOperation_ServicesSoapClient() {
        }
        
        public TaxiOperation_ServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaxiOperation_ServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaxiOperation_ServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaxiOperation_ServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiResponse FormTestServices.Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap.BookingTaxi(FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest request) {
            return base.Channel.BookingTaxi(request);
        }
        
        public string BookingTaxi(FormTestServices.Server_BookingTaxi_ThanhCong.Authentication Authentication, string CustName, string Phone, string Addr, string VehType, int Qty, System.DateTime Time, string GhiChu, int brand, short src, string dmn) {
            FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest inValue = new FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest();
            inValue.Authentication = Authentication;
            inValue.CustName = CustName;
            inValue.Phone = Phone;
            inValue.Addr = Addr;
            inValue.VehType = VehType;
            inValue.Qty = Qty;
            inValue.Time = Time;
            inValue.GhiChu = GhiChu;
            inValue.brand = brand;
            inValue.src = src;
            inValue.dmn = dmn;
            FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiResponse retVal = ((FormTestServices.Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap)(this)).BookingTaxi(inValue);
            return retVal.BookingTaxiResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiResponse> FormTestServices.Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap.BookingTaxiAsync(FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest request) {
            return base.Channel.BookingTaxiAsync(request);
        }
        
        public System.Threading.Tasks.Task<FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiResponse> BookingTaxiAsync(FormTestServices.Server_BookingTaxi_ThanhCong.Authentication Authentication, string CustName, string Phone, string Addr, string VehType, int Qty, System.DateTime Time, string GhiChu, int brand, short src, string dmn) {
            FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest inValue = new FormTestServices.Server_BookingTaxi_ThanhCong.BookingTaxiRequest();
            inValue.Authentication = Authentication;
            inValue.CustName = CustName;
            inValue.Phone = Phone;
            inValue.Addr = Addr;
            inValue.VehType = VehType;
            inValue.Qty = Qty;
            inValue.Time = Time;
            inValue.GhiChu = GhiChu;
            inValue.brand = brand;
            inValue.src = src;
            inValue.dmn = dmn;
            return ((FormTestServices.Server_BookingTaxi_ThanhCong.TaxiOperation_ServicesSoap)(this)).BookingTaxiAsync(inValue);
        }
    }
}
