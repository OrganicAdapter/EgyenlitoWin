﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 12.0.21005.1
// 
namespace EgyenlitoWin8.DataProviderService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataProviderService.IDataProviderService")]
    public interface IDataProviderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataProviderService/GetNewspapers", ReplyAction="http://tempuri.org/IDataProviderService/GetNewspapersResponse")]
        System.Threading.Tasks.Task<string> GetNewspapersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataProviderService/GetAllArticles", ReplyAction="http://tempuri.org/IDataProviderService/GetAllArticlesResponse")]
        System.Threading.Tasks.Task<string> GetAllArticlesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataProviderService/GetArticles", ReplyAction="http://tempuri.org/IDataProviderService/GetArticlesResponse")]
        System.Threading.Tasks.Task<string> GetArticlesAsync(int newspaperId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataProviderServiceChannel : EgyenlitoWin8.DataProviderService.IDataProviderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataProviderServiceClient : System.ServiceModel.ClientBase<EgyenlitoWin8.DataProviderService.IDataProviderService>, EgyenlitoWin8.DataProviderService.IDataProviderService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DataProviderServiceClient() : 
                base(DataProviderServiceClient.GetDefaultBinding(), DataProviderServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDataProviderService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataProviderServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(DataProviderServiceClient.GetBindingForEndpoint(endpointConfiguration), DataProviderServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataProviderServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DataProviderServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataProviderServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DataProviderServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataProviderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<string> GetNewspapersAsync() {
            return base.Channel.GetNewspapersAsync();
        }
        
        public System.Threading.Tasks.Task<string> GetAllArticlesAsync() {
            return base.Channel.GetAllArticlesAsync();
        }
        
        public System.Threading.Tasks.Task<string> GetArticlesAsync(int newspaperId) {
            return base.Channel.GetArticlesAsync(newspaperId);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDataProviderService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDataProviderService)) {
                return new System.ServiceModel.EndpointAddress("http://egyenlito.asphostpage.net/Egyenlito/WCF/DataProviderService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return DataProviderServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDataProviderService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return DataProviderServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDataProviderService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IDataProviderService,
        }
    }
}
