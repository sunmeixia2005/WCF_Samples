﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleServiceOne.SampleServiceTwoProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SampleServiceTwoProxy.ISampleServiceTwo")]
    public interface ISampleServiceTwo {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISampleServiceTwo/ComputeResponse", ReplyAction="http://tempuri.org/ISampleServiceTwo/ComputeResponseResponse")]
        string ComputeResponse(string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISampleServiceTwo/ComputeResponse", ReplyAction="http://tempuri.org/ISampleServiceTwo/ComputeResponseResponse")]
        System.Threading.Tasks.Task<string> ComputeResponseAsync(string input);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISampleServiceTwoChannel : ISampleServiceTwo, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SampleServiceTwoClient : System.ServiceModel.ClientBase<ISampleServiceTwo>, ISampleServiceTwo {
        
        public SampleServiceTwoClient() {
        }
        
        public SampleServiceTwoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SampleServiceTwoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SampleServiceTwoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SampleServiceTwoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ComputeResponse(string input) {
            return base.Channel.ComputeResponse(input);
        }
        
        public System.Threading.Tasks.Task<string> ComputeResponseAsync(string input) {
            return base.Channel.ComputeResponseAsync(input);
        }
    }
}
