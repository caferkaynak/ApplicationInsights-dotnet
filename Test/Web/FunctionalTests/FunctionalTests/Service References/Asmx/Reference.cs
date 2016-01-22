﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Functional.Asmx {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://TestWebService", ConfigurationName="Asmx.TestWebServiceSoap")]
    public interface TestWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestWebService/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestWebService/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestWebService/HelloPost", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloPost(bool needThrow);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestWebService/HelloPost", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloPostAsync(bool needThrow);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestWebService/ExecuteHttpCall", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ExecuteHttpCall(string url, string method);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://TestWebService/ExecuteHttpCall", ReplyAction="*")]
        System.Threading.Tasks.Task ExecuteHttpCallAsync(string url, string method);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TestWebServiceSoapChannel : Functional.Asmx.TestWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestWebServiceSoapClient : System.ServiceModel.ClientBase<Functional.Asmx.TestWebServiceSoap>, Functional.Asmx.TestWebServiceSoap {
        
        public TestWebServiceSoapClient() {
        }
        
        public TestWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TestWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public string HelloPost(bool needThrow) {
            return base.Channel.HelloPost(needThrow);
        }
        
        public System.Threading.Tasks.Task<string> HelloPostAsync(bool needThrow) {
            return base.Channel.HelloPostAsync(needThrow);
        }
        
        public void ExecuteHttpCall(string url, string method) {
            base.Channel.ExecuteHttpCall(url, method);
        }
        
        public System.Threading.Tasks.Task ExecuteHttpCallAsync(string url, string method) {
            return base.Channel.ExecuteHttpCallAsync(url, method);
        }
    }
}
