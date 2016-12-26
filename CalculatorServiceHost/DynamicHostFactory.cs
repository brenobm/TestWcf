using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.Web;

namespace CalculatorServiceHost
{
    public class DynamicHostFactory : ServiceHostFactory
    {
        public DynamicHostFactory() { }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            // Load bin/services.dll
            var asm = Assembly.Load("ServicesImpl");
            var serviceType = asm.GetType(constructorString);
            var host = new ServiceHost(serviceType, baseAddresses);

            // Add endpoints. (In this example only IHello interface)
            foreach (Type contract in serviceType.GetInterfaces())
            {
                var attribute = (ServiceContractAttribute)
                Attribute.GetCustomAttribute(contract, typeof(ServiceContractAttribute));
                if (attribute != null)
                    host.AddServiceEndpoint(contract, new WSHttpBinding(), "");
            }
            //// Add metdata behavior for generating wsdl
            //var metadata = new ServiceMetadataBehavior();
            //metadata.HttpGetEnabled = true;
            //metadata.HttpsGetEnabled = true;
            //host.Description.Behaviors.Add(metadata);

            //var debug = new ServiceDebugBehavior();
            //debug.IncludeExceptionDetailInFaults = true;
            //host.Description.Behaviors.Add(debug);
            return host;
        }
    }
}