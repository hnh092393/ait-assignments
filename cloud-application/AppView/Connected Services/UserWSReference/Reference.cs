﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppView.UserWSReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDTO", Namespace="http://schemas.datacontract.org/2004/07/AppService")]
    [System.SerializableAttribute()]
    public partial class UserDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserEmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserLevelField;
        
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
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UID {
            get {
                return this.UIDField;
            }
            set {
                if ((this.UIDField.Equals(value) != true)) {
                    this.UIDField = value;
                    this.RaisePropertyChanged("UID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserEmail {
            get {
                return this.UserEmailField;
            }
            set {
                if ((object.ReferenceEquals(this.UserEmailField, value) != true)) {
                    this.UserEmailField = value;
                    this.RaisePropertyChanged("UserEmail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserLevel {
            get {
                return this.UserLevelField;
            }
            set {
                if ((this.UserLevelField.Equals(value) != true)) {
                    this.UserLevelField = value;
                    this.RaisePropertyChanged("UserLevel");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserWSReference.IUser")]
    public interface IUser {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetAllUser", ReplyAction="http://tempuri.org/IUser/GetAllUserResponse")]
        AppView.UserWSReference.UserDTO[] GetAllUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetAllUser", ReplyAction="http://tempuri.org/IUser/GetAllUserResponse")]
        System.Threading.Tasks.Task<AppView.UserWSReference.UserDTO[]> GetAllUserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/IsUserInserted", ReplyAction="http://tempuri.org/IUser/IsUserInsertedResponse")]
        bool IsUserInserted(AppView.UserWSReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/IsUserInserted", ReplyAction="http://tempuri.org/IUser/IsUserInsertedResponse")]
        System.Threading.Tasks.Task<bool> IsUserInsertedAsync(AppView.UserWSReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/IsUserUpdated", ReplyAction="http://tempuri.org/IUser/IsUserUpdatedResponse")]
        bool IsUserUpdated(AppView.UserWSReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/IsUserUpdated", ReplyAction="http://tempuri.org/IUser/IsUserUpdatedResponse")]
        System.Threading.Tasks.Task<bool> IsUserUpdatedAsync(AppView.UserWSReference.UserDTO user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/IsUserDeleted", ReplyAction="http://tempuri.org/IUser/IsUserDeletedResponse")]
        bool IsUserDeleted(int ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/IsUserDeleted", ReplyAction="http://tempuri.org/IUser/IsUserDeletedResponse")]
        System.Threading.Tasks.Task<bool> IsUserDeletedAsync(int ID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserChannel : AppView.UserWSReference.IUser, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserClient : System.ServiceModel.ClientBase<AppView.UserWSReference.IUser>, AppView.UserWSReference.IUser {
        
        public UserClient() {
        }
        
        public UserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AppView.UserWSReference.UserDTO[] GetAllUser() {
            return base.Channel.GetAllUser();
        }
        
        public System.Threading.Tasks.Task<AppView.UserWSReference.UserDTO[]> GetAllUserAsync() {
            return base.Channel.GetAllUserAsync();
        }
        
        public bool IsUserInserted(AppView.UserWSReference.UserDTO user) {
            return base.Channel.IsUserInserted(user);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserInsertedAsync(AppView.UserWSReference.UserDTO user) {
            return base.Channel.IsUserInsertedAsync(user);
        }
        
        public bool IsUserUpdated(AppView.UserWSReference.UserDTO user) {
            return base.Channel.IsUserUpdated(user);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserUpdatedAsync(AppView.UserWSReference.UserDTO user) {
            return base.Channel.IsUserUpdatedAsync(user);
        }
        
        public bool IsUserDeleted(int ID) {
            return base.Channel.IsUserDeleted(ID);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserDeletedAsync(int ID) {
            return base.Channel.IsUserDeletedAsync(ID);
        }
    }
}
