﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Views.ServiceWeather {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WebXml.com.cn/", ConfigurationName="ServiceWeather.WeatherWebServiceSoap")]
    public interface WeatherWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportCity", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getSupportCity(string byProvinceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportCity", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> getSupportCityAsync(string byProvinceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportProvince", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getSupportProvince();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportProvince", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> getSupportProvinceAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportDataSet", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getSupportDataSet();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportDataSet", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getSupportDataSetAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getWeatherbyCityName(string theCityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityName", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> getWeatherbyCityNameAsync(string theCityName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityNamePro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getWeatherbyCityNamePro(string theCityName, string theUserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityNamePro", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> getWeatherbyCityNameProAsync(string theCityName, string theUserID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WeatherWebServiceSoapChannel : Views.ServiceWeather.WeatherWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherWebServiceSoapClient : System.ServiceModel.ClientBase<Views.ServiceWeather.WeatherWebServiceSoap>, Views.ServiceWeather.WeatherWebServiceSoap {
        
        public WeatherWebServiceSoapClient() {
        }
        
        public WeatherWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] getSupportCity(string byProvinceName) {
            return base.Channel.getSupportCity(byProvinceName);
        }
        
        public System.Threading.Tasks.Task<string[]> getSupportCityAsync(string byProvinceName) {
            return base.Channel.getSupportCityAsync(byProvinceName);
        }
        
        public string[] getSupportProvince() {
            return base.Channel.getSupportProvince();
        }
        
        public System.Threading.Tasks.Task<string[]> getSupportProvinceAsync() {
            return base.Channel.getSupportProvinceAsync();
        }
        
        public System.Data.DataSet getSupportDataSet() {
            return base.Channel.getSupportDataSet();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getSupportDataSetAsync() {
            return base.Channel.getSupportDataSetAsync();
        }
        
        public string[] getWeatherbyCityName(string theCityName) {
            return base.Channel.getWeatherbyCityName(theCityName);
        }
        
        public System.Threading.Tasks.Task<string[]> getWeatherbyCityNameAsync(string theCityName) {
            return base.Channel.getWeatherbyCityNameAsync(theCityName);
        }
        
        public string[] getWeatherbyCityNamePro(string theCityName, string theUserID) {
            return base.Channel.getWeatherbyCityNamePro(theCityName, theUserID);
        }
        
        public System.Threading.Tasks.Task<string[]> getWeatherbyCityNameProAsync(string theCityName, string theUserID) {
            return base.Channel.getWeatherbyCityNameProAsync(theCityName, theUserID);
        }
    }
}
