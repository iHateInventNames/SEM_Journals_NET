﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEM.WpfDestopApp.JournalsServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Subscription", Namespace="http://schemas.datacontract.org/2004/07/SEM.WcfServiceApplication")]
    [System.SerializableAttribute()]
    public partial class Subscription : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int JournalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
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
        public int JournalId {
            get {
                return this.JournalIdField;
            }
            set {
                if ((this.JournalIdField.Equals(value) != true)) {
                    this.JournalIdField = value;
                    this.RaisePropertyChanged("JournalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JournalsServiceReference.IServiceJournalsAccess")]
    public interface IServiceJournalsAccess {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceJournalsAccess/GetJournal", ReplyAction="http://tempuri.org/IServiceJournalsAccess/GetJournalResponse")]
        byte[] GetJournal(string login, string password, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceJournalsAccess/GetJournal", ReplyAction="http://tempuri.org/IServiceJournalsAccess/GetJournalResponse")]
        System.Threading.Tasks.Task<byte[]> GetJournalAsync(string login, string password, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceJournalsAccess/GetMySubscriptions", ReplyAction="http://tempuri.org/IServiceJournalsAccess/GetMySubscriptionsResponse")]
        SEM.WpfDestopApp.JournalsServiceReference.Subscription[] GetMySubscriptions(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceJournalsAccess/GetMySubscriptions", ReplyAction="http://tempuri.org/IServiceJournalsAccess/GetMySubscriptionsResponse")]
        System.Threading.Tasks.Task<SEM.WpfDestopApp.JournalsServiceReference.Subscription[]> GetMySubscriptionsAsync(string login, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceJournalsAccessChannel : SEM.WpfDestopApp.JournalsServiceReference.IServiceJournalsAccess, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceJournalsAccessClient : System.ServiceModel.ClientBase<SEM.WpfDestopApp.JournalsServiceReference.IServiceJournalsAccess>, SEM.WpfDestopApp.JournalsServiceReference.IServiceJournalsAccess {
        
        public ServiceJournalsAccessClient() {
        }
        
        public ServiceJournalsAccessClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceJournalsAccessClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceJournalsAccessClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceJournalsAccessClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public byte[] GetJournal(string login, string password, int value) {
            return base.Channel.GetJournal(login, password, value);
        }
        
        public System.Threading.Tasks.Task<byte[]> GetJournalAsync(string login, string password, int value) {
            return base.Channel.GetJournalAsync(login, password, value);
        }
        
        public SEM.WpfDestopApp.JournalsServiceReference.Subscription[] GetMySubscriptions(string login, string password) {
            return base.Channel.GetMySubscriptions(login, password);
        }
        
        public System.Threading.Tasks.Task<SEM.WpfDestopApp.JournalsServiceReference.Subscription[]> GetMySubscriptionsAsync(string login, string password) {
            return base.Channel.GetMySubscriptionsAsync(login, password);
        }
    }
}
