﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ChatService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RUser", Namespace="http://schemas.datacontract.org/2004/07/Server.Base.Tables")]
    [System.SerializableAttribute()]
    public partial class RUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BlockedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastActivityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool OnlineField;
        
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
        public bool Blocked {
            get {
                return this.BlockedField;
            }
            set {
                if ((this.BlockedField.Equals(value) != true)) {
                    this.BlockedField = value;
                    this.RaisePropertyChanged("Blocked");
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
        public System.DateTime LastActivity {
            get {
                return this.LastActivityField;
            }
            set {
                if ((this.LastActivityField.Equals(value) != true)) {
                    this.LastActivityField = value;
                    this.RaisePropertyChanged("LastActivity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Online {
            get {
                return this.OnlineField;
            }
            set {
                if ((this.OnlineField.Equals(value) != true)) {
                    this.OnlineField = value;
                    this.RaisePropertyChanged("Online");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RGroupMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Base.Tables")]
    [System.SerializableAttribute()]
    public partial class RGroupMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DeletedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int GroupIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageSourceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIDField;
        
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
        public bool Deleted {
            get {
                return this.DeletedField;
            }
            set {
                if ((this.DeletedField.Equals(value) != true)) {
                    this.DeletedField = value;
                    this.RaisePropertyChanged("Deleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int GroupID {
            get {
                return this.GroupIDField;
            }
            set {
                if ((this.GroupIDField.Equals(value) != true)) {
                    this.GroupIDField = value;
                    this.RaisePropertyChanged("GroupID");
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
        public string MessageSource {
            get {
                return this.MessageSourceField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageSourceField, value) != true)) {
                    this.MessageSourceField = value;
                    this.RaisePropertyChanged("MessageSource");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserID {
            get {
                return this.UserIDField;
            }
            set {
                if ((this.UserIDField.Equals(value) != true)) {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RMUserInGroup", Namespace="http://schemas.datacontract.org/2004/07/Server.Base.Tables")]
    [System.SerializableAttribute()]
    public partial class RMUserInGroup : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FriendIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.ChatService.RGroup GroupField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool MutedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.ChatService.RRole RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.ChatService.RUser UserField;
        
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
        public int FriendID {
            get {
                return this.FriendIDField;
            }
            set {
                if ((this.FriendIDField.Equals(value) != true)) {
                    this.FriendIDField = value;
                    this.RaisePropertyChanged("FriendID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.ChatService.RGroup Group {
            get {
                return this.GroupField;
            }
            set {
                if ((object.ReferenceEquals(this.GroupField, value) != true)) {
                    this.GroupField = value;
                    this.RaisePropertyChanged("Group");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Muted {
            get {
                return this.MutedField;
            }
            set {
                if ((this.MutedField.Equals(value) != true)) {
                    this.MutedField = value;
                    this.RaisePropertyChanged("Muted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.ChatService.RRole Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.ChatService.RUser User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RGroup", Namespace="http://schemas.datacontract.org/2004/07/Server.Base.Tables")]
    [System.SerializableAttribute()]
    public partial class RGroup : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DeletedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public bool Deleted {
            get {
                return this.DeletedField;
            }
            set {
                if ((this.DeletedField.Equals(value) != true)) {
                    this.DeletedField = value;
                    this.RaisePropertyChanged("Deleted");
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RRole", Namespace="http://schemas.datacontract.org/2004/07/Server.Base.Tables")]
    [System.SerializableAttribute()]
    public partial class RRole : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatService.IChatService", CallbackContract=typeof(Client.ChatService.IChatServiceCallback))]
    public interface IChatService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Register")]
        void Register(string Login, string Email, string Password, string repeatPassword);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Register")]
        System.Threading.Tasks.Task RegisterAsync(string Login, string Email, string Password, string repeatPassword);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Login")]
        void Login([System.ServiceModel.MessageParameterAttribute(Name="Login")] string Login1, string Password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Login")]
        System.Threading.Tasks.Task LoginAsync(string Login, string Password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Leave")]
        void Leave();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Leave")]
        System.Threading.Tasks.Task LeaveAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendMessage")]
        void SendMessage(int groupID, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(int groupID, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/GetMyGroups")]
        void GetMyGroups();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/GetMyGroups")]
        System.Threading.Tasks.Task GetMyGroupsAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/CreateGroup")]
        void CreateGroup(string Name, int[] IDs);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/CreateGroup")]
        System.Threading.Tasks.Task CreateGroupAsync(string Name, int[] IDs);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/LeaveGroup")]
        void LeaveGroup(int ID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/LeaveGroup")]
        System.Threading.Tasks.Task LeaveGroupAsync(int ID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/AddUsersToGroup")]
        void AddUsersToGroup(int ID, int[] IDs);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/AddUsersToGroup")]
        System.Threading.Tasks.Task AddUsersToGroupAsync(int ID, int[] IDs);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RemoveUserFromGroup")]
        void RemoveUserFromGroup(int groupID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RemoveUserFromGroup")]
        System.Threading.Tasks.Task RemoveUserFromGroupAsync(int groupID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/EditRoleUserInGroup")]
        void EditRoleUserInGroup(int groupID, int userID, int roleID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/EditRoleUserInGroup")]
        System.Threading.Tasks.Task EditRoleUserInGroupAsync(int groupID, int userID, int roleID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/MuteUserInGroup")]
        void MuteUserInGroup(int groupID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/MuteUserInGroup")]
        System.Threading.Tasks.Task MuteUserInGroupAsync(int groupID, int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsers", ReplyAction="http://tempuri.org/IChatService/GetUsersResponse")]
        Client.ChatService.RUser[] GetUsers(int offset, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsers", ReplyAction="http://tempuri.org/IChatService/GetUsersResponse")]
        System.Threading.Tasks.Task<Client.ChatService.RUser[]> GetUsersAsync(int offset, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetMessages", ReplyAction="http://tempuri.org/IChatService/GetMessagesResponse")]
        System.Collections.Generic.Dictionary<Client.ChatService.RUser, Client.ChatService.RGroupMessage> GetMessages(int groupID, bool reverced, int count, int offset);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetMessages", ReplyAction="http://tempuri.org/IChatService/GetMessagesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<Client.ChatService.RUser, Client.ChatService.RGroupMessage>> GetMessagesAsync(int groupID, bool reverced, int count, int offset);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsersInGroup", ReplyAction="http://tempuri.org/IChatService/GetUsersInGroupResponse")]
        Client.ChatService.RMUserInGroup[] GetUsersInGroup(int groupID, int offset, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsersInGroup", ReplyAction="http://tempuri.org/IChatService/GetUsersInGroupResponse")]
        System.Threading.Tasks.Task<Client.ChatService.RMUserInGroup[]> GetUsersInGroupAsync(int groupID, int offset, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsersOutGroup", ReplyAction="http://tempuri.org/IChatService/GetUsersOutGroupResponse")]
        Client.ChatService.RUser[] GetUsersOutGroup(int groupID, int offset, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetUsersOutGroup", ReplyAction="http://tempuri.org/IChatService/GetUsersOutGroupResponse")]
        System.Threading.Tasks.Task<Client.ChatService.RUser[]> GetUsersOutGroupAsync(int groupID, int offset, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetCountUsers", ReplyAction="http://tempuri.org/IChatService/GetCountUsersResponse")]
        int GetCountUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetCountUsers", ReplyAction="http://tempuri.org/IChatService/GetCountUsersResponse")]
        System.Threading.Tasks.Task<int> GetCountUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetCountUsersInGroup", ReplyAction="http://tempuri.org/IChatService/GetCountUsersInGroupResponse")]
        int GetCountUsersInGroup(int groupID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetCountUsersInGroup", ReplyAction="http://tempuri.org/IChatService/GetCountUsersInGroupResponse")]
        System.Threading.Tasks.Task<int> GetCountUsersInGroupAsync(int groupID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetCountMessages", ReplyAction="http://tempuri.org/IChatService/GetCountMessagesResponse")]
        int GetCountMessages(int groupID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetCountMessages", ReplyAction="http://tempuri.org/IChatService/GetCountMessagesResponse")]
        System.Threading.Tasks.Task<int> GetCountMessagesAsync(int groupID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Error")]
        void Error(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/Message")]
        void Message([System.ServiceModel.MessageParameterAttribute(Name="message")] string message1);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RLogin")]
        void RLogin(Client.ChatService.RUser usr);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RLeave")]
        void RLeave();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RChangeOnline")]
        void RChangeOnline(Client.ChatService.RUser usr);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RNewUser")]
        void RNewUser(Client.ChatService.RUser usr);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RGroups")]
        void RGroups(Client.ChatService.RMUserInGroup[] groups);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RLeaveGroup")]
        void RLeaveGroup(Client.ChatService.RGroup group);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RNewGroup")]
        void RNewGroup(Client.ChatService.RMUserInGroup usrInGrp);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RNewUsersInGroup")]
        void RNewUsersInGroup(Client.ChatService.RMUserInGroup[] users);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RLeaveUserInGroup")]
        void RLeaveUserInGroup(Client.ChatService.RGroup group, Client.ChatService.RUser usr);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/RNewMessage")]
        void RNewMessage(Client.ChatService.RUser user, Client.ChatService.RGroupMessage msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceChannel : Client.ChatService.IChatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServiceClient : System.ServiceModel.DuplexClientBase<Client.ChatService.IChatService>, Client.ChatService.IChatService {
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Register(string Login, string Email, string Password, string repeatPassword) {
            base.Channel.Register(Login, Email, Password, repeatPassword);
        }
        
        public System.Threading.Tasks.Task RegisterAsync(string Login, string Email, string Password, string repeatPassword) {
            return base.Channel.RegisterAsync(Login, Email, Password, repeatPassword);
        }
        
        public void Login(string Login1, string Password) {
            base.Channel.Login(Login1, Password);
        }
        
        public System.Threading.Tasks.Task LoginAsync(string Login, string Password) {
            return base.Channel.LoginAsync(Login, Password);
        }
        
        public void Leave() {
            base.Channel.Leave();
        }
        
        public System.Threading.Tasks.Task LeaveAsync() {
            return base.Channel.LeaveAsync();
        }
        
        public void SendMessage(int groupID, string message) {
            base.Channel.SendMessage(groupID, message);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(int groupID, string message) {
            return base.Channel.SendMessageAsync(groupID, message);
        }
        
        public void GetMyGroups() {
            base.Channel.GetMyGroups();
        }
        
        public System.Threading.Tasks.Task GetMyGroupsAsync() {
            return base.Channel.GetMyGroupsAsync();
        }
        
        public void CreateGroup(string Name, int[] IDs) {
            base.Channel.CreateGroup(Name, IDs);
        }
        
        public System.Threading.Tasks.Task CreateGroupAsync(string Name, int[] IDs) {
            return base.Channel.CreateGroupAsync(Name, IDs);
        }
        
        public void LeaveGroup(int ID) {
            base.Channel.LeaveGroup(ID);
        }
        
        public System.Threading.Tasks.Task LeaveGroupAsync(int ID) {
            return base.Channel.LeaveGroupAsync(ID);
        }
        
        public void AddUsersToGroup(int ID, int[] IDs) {
            base.Channel.AddUsersToGroup(ID, IDs);
        }
        
        public System.Threading.Tasks.Task AddUsersToGroupAsync(int ID, int[] IDs) {
            return base.Channel.AddUsersToGroupAsync(ID, IDs);
        }
        
        public void RemoveUserFromGroup(int groupID, int userID) {
            base.Channel.RemoveUserFromGroup(groupID, userID);
        }
        
        public System.Threading.Tasks.Task RemoveUserFromGroupAsync(int groupID, int userID) {
            return base.Channel.RemoveUserFromGroupAsync(groupID, userID);
        }
        
        public void EditRoleUserInGroup(int groupID, int userID, int roleID) {
            base.Channel.EditRoleUserInGroup(groupID, userID, roleID);
        }
        
        public System.Threading.Tasks.Task EditRoleUserInGroupAsync(int groupID, int userID, int roleID) {
            return base.Channel.EditRoleUserInGroupAsync(groupID, userID, roleID);
        }
        
        public void MuteUserInGroup(int groupID, int userID) {
            base.Channel.MuteUserInGroup(groupID, userID);
        }
        
        public System.Threading.Tasks.Task MuteUserInGroupAsync(int groupID, int userID) {
            return base.Channel.MuteUserInGroupAsync(groupID, userID);
        }
        
        public Client.ChatService.RUser[] GetUsers(int offset, int count) {
            return base.Channel.GetUsers(offset, count);
        }
        
        public System.Threading.Tasks.Task<Client.ChatService.RUser[]> GetUsersAsync(int offset, int count) {
            return base.Channel.GetUsersAsync(offset, count);
        }
        
        public System.Collections.Generic.Dictionary<Client.ChatService.RUser, Client.ChatService.RGroupMessage> GetMessages(int groupID, bool reverced, int count, int offset) {
            return base.Channel.GetMessages(groupID, reverced, count, offset);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<Client.ChatService.RUser, Client.ChatService.RGroupMessage>> GetMessagesAsync(int groupID, bool reverced, int count, int offset) {
            return base.Channel.GetMessagesAsync(groupID, reverced, count, offset);
        }
        
        public Client.ChatService.RMUserInGroup[] GetUsersInGroup(int groupID, int offset, int count) {
            return base.Channel.GetUsersInGroup(groupID, offset, count);
        }
        
        public System.Threading.Tasks.Task<Client.ChatService.RMUserInGroup[]> GetUsersInGroupAsync(int groupID, int offset, int count) {
            return base.Channel.GetUsersInGroupAsync(groupID, offset, count);
        }
        
        public Client.ChatService.RUser[] GetUsersOutGroup(int groupID, int offset, int count) {
            return base.Channel.GetUsersOutGroup(groupID, offset, count);
        }
        
        public System.Threading.Tasks.Task<Client.ChatService.RUser[]> GetUsersOutGroupAsync(int groupID, int offset, int count) {
            return base.Channel.GetUsersOutGroupAsync(groupID, offset, count);
        }
        
        public int GetCountUsers() {
            return base.Channel.GetCountUsers();
        }
        
        public System.Threading.Tasks.Task<int> GetCountUsersAsync() {
            return base.Channel.GetCountUsersAsync();
        }
        
        public int GetCountUsersInGroup(int groupID) {
            return base.Channel.GetCountUsersInGroup(groupID);
        }
        
        public System.Threading.Tasks.Task<int> GetCountUsersInGroupAsync(int groupID) {
            return base.Channel.GetCountUsersInGroupAsync(groupID);
        }
        
        public int GetCountMessages(int groupID) {
            return base.Channel.GetCountMessages(groupID);
        }
        
        public System.Threading.Tasks.Task<int> GetCountMessagesAsync(int groupID) {
            return base.Channel.GetCountMessagesAsync(groupID);
        }
    }
}
