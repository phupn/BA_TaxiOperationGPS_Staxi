﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.6387
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxiOperation_TongDai.WCFSyncService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestBase", Namespace="WCF_SyncOnline.ServiceLibrary")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TaxiOperation_TongDai.WCFSyncService.XeOnlineRequest))]
    public partial class RequestBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccessTokenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ActionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ClientTagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] LoadOptionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RequestIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
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
        public string AccessToken {
            get {
                return this.AccessTokenField;
            }
            set {
                if ((object.ReferenceEquals(this.AccessTokenField, value) != true)) {
                    this.AccessTokenField = value;
                    this.RaisePropertyChanged("AccessToken");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Action {
            get {
                return this.ActionField;
            }
            set {
                if ((object.ReferenceEquals(this.ActionField, value) != true)) {
                    this.ActionField = value;
                    this.RaisePropertyChanged("Action");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ClientTag {
            get {
                return this.ClientTagField;
            }
            set {
                if ((object.ReferenceEquals(this.ClientTagField, value) != true)) {
                    this.ClientTagField = value;
                    this.RaisePropertyChanged("ClientTag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] LoadOptions {
            get {
                return this.LoadOptionsField;
            }
            set {
                if ((object.ReferenceEquals(this.LoadOptionsField, value) != true)) {
                    this.LoadOptionsField = value;
                    this.RaisePropertyChanged("LoadOptions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RequestId {
            get {
                return this.RequestIdField;
            }
            set {
                if ((object.ReferenceEquals(this.RequestIdField, value) != true)) {
                    this.RequestIdField = value;
                    this.RaisePropertyChanged("RequestId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="XeOnlineRequest", Namespace="WCF_SyncOnline.ServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class XeOnlineRequest : TaxiOperation_TongDai.WCFSyncService.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BKGioiHanField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BKSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double KDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoaiXeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaXNField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SHXField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SLXeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double VDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BKGioiHan {
            get {
                return this.BKGioiHanField;
            }
            set {
                if ((this.BKGioiHanField.Equals(value) != true)) {
                    this.BKGioiHanField = value;
                    this.RaisePropertyChanged("BKGioiHan");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BKS {
            get {
                return this.BKSField;
            }
            set {
                if ((object.ReferenceEquals(this.BKSField, value) != true)) {
                    this.BKSField = value;
                    this.RaisePropertyChanged("BKS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double KD {
            get {
                return this.KDField;
            }
            set {
                if ((this.KDField.Equals(value) != true)) {
                    this.KDField = value;
                    this.RaisePropertyChanged("KD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastTime {
            get {
                return this.LastTimeField;
            }
            set {
                if ((this.LastTimeField.Equals(value) != true)) {
                    this.LastTimeField = value;
                    this.RaisePropertyChanged("LastTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoaiXe {
            get {
                return this.LoaiXeField;
            }
            set {
                if ((object.ReferenceEquals(this.LoaiXeField, value) != true)) {
                    this.LoaiXeField = value;
                    this.RaisePropertyChanged("LoaiXe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MaXN {
            get {
                return this.MaXNField;
            }
            set {
                if ((object.ReferenceEquals(this.MaXNField, value) != true)) {
                    this.MaXNField = value;
                    this.RaisePropertyChanged("MaXN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SHX {
            get {
                return this.SHXField;
            }
            set {
                if ((object.ReferenceEquals(this.SHXField, value) != true)) {
                    this.SHXField = value;
                    this.RaisePropertyChanged("SHX");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SLXe {
            get {
                return this.SLXeField;
            }
            set {
                if ((this.SLXeField.Equals(value) != true)) {
                    this.SLXeField = value;
                    this.RaisePropertyChanged("SLXe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double VD {
            get {
                return this.VDField;
            }
            set {
                if ((this.VDField.Equals(value) != true)) {
                    this.VDField = value;
                    this.RaisePropertyChanged("VD");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseBase", Namespace="WCF_SyncOnline.ServiceLibrary")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TaxiOperation_TongDai.WCFSyncService.XeOnlineResponse))]
    public partial class ResponseBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TaxiOperation_TongDai.WCFSyncService.AcknowledgeType AcknowledgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorrelationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ReservationExpiresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReservationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RowsAffectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
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
        public TaxiOperation_TongDai.WCFSyncService.AcknowledgeType Acknowledge {
            get {
                return this.AcknowledgeField;
            }
            set {
                if ((this.AcknowledgeField.Equals(value) != true)) {
                    this.AcknowledgeField = value;
                    this.RaisePropertyChanged("Acknowledge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Build {
            get {
                return this.BuildField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildField, value) != true)) {
                    this.BuildField = value;
                    this.RaisePropertyChanged("Build");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CorrelationId {
            get {
                return this.CorrelationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CorrelationIdField, value) != true)) {
                    this.CorrelationIdField = value;
                    this.RaisePropertyChanged("CorrelationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ReservationExpires {
            get {
                return this.ReservationExpiresField;
            }
            set {
                if ((this.ReservationExpiresField.Equals(value) != true)) {
                    this.ReservationExpiresField = value;
                    this.RaisePropertyChanged("ReservationExpires");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReservationId {
            get {
                return this.ReservationIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ReservationIdField, value) != true)) {
                    this.ReservationIdField = value;
                    this.RaisePropertyChanged("ReservationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RowsAffected {
            get {
                return this.RowsAffectedField;
            }
            set {
                if ((this.RowsAffectedField.Equals(value) != true)) {
                    this.RowsAffectedField = value;
                    this.RaisePropertyChanged("RowsAffected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="XeOnlineResponse", Namespace="WCF_SyncOnline.ServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class XeOnlineResponse : TaxiOperation_TongDai.WCFSyncService.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TaxiOperation_TongDai.WCFSyncService.T_XeOnline XeOnlineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TaxiOperation_TongDai.WCFSyncService.T_XeOnline[] XeOnlinesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TaxiOperation_TongDai.WCFSyncService.T_XeOnline XeOnline {
            get {
                return this.XeOnlineField;
            }
            set {
                if ((object.ReferenceEquals(this.XeOnlineField, value) != true)) {
                    this.XeOnlineField = value;
                    this.RaisePropertyChanged("XeOnline");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TaxiOperation_TongDai.WCFSyncService.T_XeOnline[] XeOnlines {
            get {
                return this.XeOnlinesField;
            }
            set {
                if ((object.ReferenceEquals(this.XeOnlinesField, value) != true)) {
                    this.XeOnlinesField = value;
                    this.RaisePropertyChanged("XeOnlines");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AcknowledgeType", Namespace="WCF_SyncOnline.ServiceLibrary")]
    public enum AcknowledgeType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Failure = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="T_XeOnline", Namespace="http://schemas.datacontract.org/2004/07/WCF_SyncOnline.ServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class T_XeOnline : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BienSoXeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiemGiaoCaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DoiXeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GaraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HuongDiChuyenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ID_OnlineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double KhoangCachField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float KinhDoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoaiXeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LoaiXeGPSField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaCungXNField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SoChoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SoHieuXeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TGCapNhatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TGDiChuyenGanNhatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ThoiDiemChenDuLieuField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ThoiDiemXeGuiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TrangThaiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float ViDoField;
        
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
        public string BienSoXe {
            get {
                return this.BienSoXeField;
            }
            set {
                if ((object.ReferenceEquals(this.BienSoXeField, value) != true)) {
                    this.BienSoXeField = value;
                    this.RaisePropertyChanged("BienSoXe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DiemGiaoCa {
            get {
                return this.DiemGiaoCaField;
            }
            set {
                if ((object.ReferenceEquals(this.DiemGiaoCaField, value) != true)) {
                    this.DiemGiaoCaField = value;
                    this.RaisePropertyChanged("DiemGiaoCa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DoiXe {
            get {
                return this.DoiXeField;
            }
            set {
                if ((object.ReferenceEquals(this.DoiXeField, value) != true)) {
                    this.DoiXeField = value;
                    this.RaisePropertyChanged("DoiXe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gara {
            get {
                return this.GaraField;
            }
            set {
                if ((object.ReferenceEquals(this.GaraField, value) != true)) {
                    this.GaraField = value;
                    this.RaisePropertyChanged("Gara");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HuongDiChuyen {
            get {
                return this.HuongDiChuyenField;
            }
            set {
                if ((this.HuongDiChuyenField.Equals(value) != true)) {
                    this.HuongDiChuyenField = value;
                    this.RaisePropertyChanged("HuongDiChuyen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_Online {
            get {
                return this.ID_OnlineField;
            }
            set {
                if ((this.ID_OnlineField.Equals(value) != true)) {
                    this.ID_OnlineField = value;
                    this.RaisePropertyChanged("ID_Online");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double KhoangCach {
            get {
                return this.KhoangCachField;
            }
            set {
                if ((this.KhoangCachField.Equals(value) != true)) {
                    this.KhoangCachField = value;
                    this.RaisePropertyChanged("KhoangCach");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float KinhDo {
            get {
                return this.KinhDoField;
            }
            set {
                if ((this.KinhDoField.Equals(value) != true)) {
                    this.KinhDoField = value;
                    this.RaisePropertyChanged("KinhDo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoaiXe {
            get {
                return this.LoaiXeField;
            }
            set {
                if ((object.ReferenceEquals(this.LoaiXeField, value) != true)) {
                    this.LoaiXeField = value;
                    this.RaisePropertyChanged("LoaiXe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LoaiXeGPS {
            get {
                return this.LoaiXeGPSField;
            }
            set {
                if ((this.LoaiXeGPSField.Equals(value) != true)) {
                    this.LoaiXeGPSField = value;
                    this.RaisePropertyChanged("LoaiXeGPS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MaCungXN {
            get {
                return this.MaCungXNField;
            }
            set {
                if ((object.ReferenceEquals(this.MaCungXNField, value) != true)) {
                    this.MaCungXNField = value;
                    this.RaisePropertyChanged("MaCungXN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SoCho {
            get {
                return this.SoChoField;
            }
            set {
                if ((this.SoChoField.Equals(value) != true)) {
                    this.SoChoField = value;
                    this.RaisePropertyChanged("SoCho");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SoHieuXe {
            get {
                return this.SoHieuXeField;
            }
            set {
                if ((object.ReferenceEquals(this.SoHieuXeField, value) != true)) {
                    this.SoHieuXeField = value;
                    this.RaisePropertyChanged("SoHieuXe");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TGCapNhat {
            get {
                return this.TGCapNhatField;
            }
            set {
                if ((this.TGCapNhatField.Equals(value) != true)) {
                    this.TGCapNhatField = value;
                    this.RaisePropertyChanged("TGCapNhat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TGDiChuyenGanNhat {
            get {
                return this.TGDiChuyenGanNhatField;
            }
            set {
                if ((this.TGDiChuyenGanNhatField.Equals(value) != true)) {
                    this.TGDiChuyenGanNhatField = value;
                    this.RaisePropertyChanged("TGDiChuyenGanNhat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ThoiDiemChenDuLieu {
            get {
                return this.ThoiDiemChenDuLieuField;
            }
            set {
                if ((this.ThoiDiemChenDuLieuField.Equals(value) != true)) {
                    this.ThoiDiemChenDuLieuField = value;
                    this.RaisePropertyChanged("ThoiDiemChenDuLieu");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ThoiDiemXeGui {
            get {
                return this.ThoiDiemXeGuiField;
            }
            set {
                if ((this.ThoiDiemXeGuiField.Equals(value) != true)) {
                    this.ThoiDiemXeGuiField = value;
                    this.RaisePropertyChanged("ThoiDiemXeGui");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TrangThai {
            get {
                return this.TrangThaiField;
            }
            set {
                if ((this.TrangThaiField.Equals(value) != true)) {
                    this.TrangThaiField = value;
                    this.RaisePropertyChanged("TrangThai");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float ViDo {
            get {
                return this.ViDoField;
            }
            set {
                if ((this.ViDoField.Equals(value) != true)) {
                    this.ViDoField = value;
                    this.RaisePropertyChanged("ViDo");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFSyncService.ISyncServiceOnline")]
    public interface ISyncServiceOnline {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncServiceOnline/GetXeOnline", ReplyAction="http://tempuri.org/ISyncServiceOnline/GetXeOnlineResponse")]
        TaxiOperation_TongDai.WCFSyncService.XeOnlineResponse GetXeOnline(TaxiOperation_TongDai.WCFSyncService.XeOnlineRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncServiceOnline/GetKCXeNhan_DiemDonKhach", ReplyAction="http://tempuri.org/ISyncServiceOnline/GetKCXeNhan_DiemDonKhachResponse")]
        double GetKCXeNhan_DiemDonKhach(double KD, double VD, string MaXN, string SHXe);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncServiceOnline/GetXeOnlineBySHX", ReplyAction="http://tempuri.org/ISyncServiceOnline/GetXeOnlineBySHXResponse")]
        TaxiOperation_TongDai.WCFSyncService.T_XeOnline GetXeOnlineBySHX(string SHXe);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncServiceOnline/LayDanhSachXeDeCu_ToaDo", ReplyAction="http://tempuri.org/ISyncServiceOnline/LayDanhSachXeDeCu_ToaDoResponse")]
        string LayDanhSachXeDeCu_ToaDo(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISyncServiceOnline/LayDanhSachXeDeCu_ToaDo_SANBAY", ReplyAction="http://tempuri.org/ISyncServiceOnline/LayDanhSachXeDeCu_ToaDo_SANBAYResponse")]
        string LayDanhSachXeDeCu_ToaDo_SANBAY(double KD, double VD, string maXN, string loaiXe, int soLuongXe);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ISyncServiceOnlineChannel : TaxiOperation_TongDai.WCFSyncService.ISyncServiceOnline, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SyncServiceOnlineClient : System.ServiceModel.ClientBase<TaxiOperation_TongDai.WCFSyncService.ISyncServiceOnline>, TaxiOperation_TongDai.WCFSyncService.ISyncServiceOnline {
        
        public SyncServiceOnlineClient() {
        }
        
        public SyncServiceOnlineClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SyncServiceOnlineClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncServiceOnlineClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SyncServiceOnlineClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TaxiOperation_TongDai.WCFSyncService.XeOnlineResponse GetXeOnline(TaxiOperation_TongDai.WCFSyncService.XeOnlineRequest request) {
            return base.Channel.GetXeOnline(request);
        }
        
        public double GetKCXeNhan_DiemDonKhach(double KD, double VD, string MaXN, string SHXe) {
            return base.Channel.GetKCXeNhan_DiemDonKhach(KD, VD, MaXN, SHXe);
        }
        
        public TaxiOperation_TongDai.WCFSyncService.T_XeOnline GetXeOnlineBySHX(string SHXe) {
            return base.Channel.GetXeOnlineBySHX(SHXe);
        }
        
        public string LayDanhSachXeDeCu_ToaDo(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe) {
            return base.Channel.LayDanhSachXeDeCu_ToaDo(KD, VD, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe);
        }
        
        public string LayDanhSachXeDeCu_ToaDo_SANBAY(double KD, double VD, string maXN, string loaiXe, int soLuongXe) {
            return base.Channel.LayDanhSachXeDeCu_ToaDo_SANBAY(KD, VD, maXN, loaiXe, soLuongXe);
        }
    }
}