﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Taxi.Services.BAGPS {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BAGPS.ServiceSoap")]
    public interface ServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGeobyAddressBA", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetGeobyAddressBA(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGeobyAddressBA3", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetGeobyAddressBA3(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGeobyAddressBA_HN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetGeobyAddressBA_HN(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAddressByGeo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetAddressByGeo(float lat, float lng);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayToaDoXeNhan", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayToaDoXeNhan(double KD, double VD, string maXN, string SoHieuXe);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachXeDeCu_ToaDo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayDanhSachXeDeCu_ToaDo(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachXeDeCu_DiaChi", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayDanhSachXeDeCu_DiaChi(string diaChi, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachXeDeCu_DiaChi3", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayDanhSachXeDeCu_DiaChi3(string diaChi, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachXeToiDiem", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayDanhSachXeToiDiem(string cuocCanKiemTraXeToiDiems, int soGiayGioiHanCoTinHieu, string maCungXNs, int banKinhGioiHan);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachXeToiDiemDonDuocKhach", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayDanhSachXeToiDiemDonDuocKhach(string cuocCanKiemTraXeToiDiemDonKhachs, int soGiayGioiHanCoTinHieu, string maCungXNs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetViTriOnline", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GetViTriOnline(System.DateTime TGLayGuLieuTruoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetLicense", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Taxi.Services.BAGPS.LicenseEntity GetLicense(string requestKey);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class LicenseEntity : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string licenseKeyField;
        
        private System.DateTime fromDateField;
        
        private System.DateTime toDateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string LicenseKey {
            get {
                return this.licenseKeyField;
            }
            set {
                this.licenseKeyField = value;
                this.RaisePropertyChanged("LicenseKey");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime FromDate {
            get {
                return this.fromDateField;
            }
            set {
                this.fromDateField = value;
                this.RaisePropertyChanged("FromDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.DateTime ToDate {
            get {
                return this.toDateField;
            }
            set {
                this.toDateField = value;
                this.RaisePropertyChanged("ToDate");
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
    public interface ServiceSoapChannel : Taxi.Services.BAGPS.ServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<Taxi.Services.BAGPS.ServiceSoap>, Taxi.Services.BAGPS.ServiceSoap {
        
        public ServiceSoapClient() {
        }
        
        public ServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public string GetGeobyAddressBA(string address) {
            return base.Channel.GetGeobyAddressBA(address);
        }
        
        public string GetGeobyAddressBA3(string address) {
            return base.Channel.GetGeobyAddressBA3(address);
        }
        
        public string GetGeobyAddressBA_HN(string address) {
            return base.Channel.GetGeobyAddressBA_HN(address);
        }
        
        public string GetAddressByGeo(float lat, float lng) {
            return base.Channel.GetAddressByGeo(lat, lng);
        }
        
        public string LayToaDoXeNhan(double KD, double VD, string maXN, string SoHieuXe) {
            return base.Channel.LayToaDoXeNhan(KD, VD, maXN, SoHieuXe);
        }
        
        public string LayDanhSachXeDeCu_ToaDo(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe) {
            return base.Channel.LayDanhSachXeDeCu_ToaDo(KD, VD, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe);
        }
        
        public string LayDanhSachXeDeCu_DiaChi(string diaChi, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe) {
            return base.Channel.LayDanhSachXeDeCu_DiaChi(diaChi, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe);
        }
        
        public string LayDanhSachXeDeCu_DiaChi3(string diaChi, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe) {
            return base.Channel.LayDanhSachXeDeCu_DiaChi3(diaChi, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe);
        }
        
        public string LayDanhSachXeToiDiem(string cuocCanKiemTraXeToiDiems, int soGiayGioiHanCoTinHieu, string maCungXNs, int banKinhGioiHan) {
            return base.Channel.LayDanhSachXeToiDiem(cuocCanKiemTraXeToiDiems, soGiayGioiHanCoTinHieu, maCungXNs, banKinhGioiHan);
        }
        
        public string LayDanhSachXeToiDiemDonDuocKhach(string cuocCanKiemTraXeToiDiemDonKhachs, int soGiayGioiHanCoTinHieu, string maCungXNs) {
            return base.Channel.LayDanhSachXeToiDiemDonDuocKhach(cuocCanKiemTraXeToiDiemDonKhachs, soGiayGioiHanCoTinHieu, maCungXNs);
        }
        
        public System.Data.DataTable GetViTriOnline(System.DateTime TGLayGuLieuTruoc) {
            return base.Channel.GetViTriOnline(TGLayGuLieuTruoc);
        }
        
        public Taxi.Services.BAGPS.LicenseEntity GetLicense(string requestKey) {
            return base.Channel.GetLicense(requestKey);
        }
    }
}
