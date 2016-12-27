using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Web;

namespace TestServiceWhitoutProxySite.Helpers
{
    public static class ServiceFactoryHelper<TServiceContract>
    {
        public static TServiceContract GetService()
        {     
            ChannelFactory<TServiceContract> factory = null;
            WSHttpBinding binding = new WSHttpBinding();
            CustomEndpointBehavior ceb = new CustomEndpointBehavior();
         
            EndpointAddress address = new EndpointAddress(new Uri(GetServiceAdress()));

            factory = new ChannelFactory<TServiceContract>(binding, address);
            factory.Endpoint.EndpointBehaviors.Add(ceb);
            TServiceContract channel = factory.CreateChannel();
            
            return channel;
        }

        private static string GetServiceAdress()
        {
            string url;
            string serviceName;

            serviceName = typeof(TServiceContract).Name;

            ServiceConfigurationSection config = (ServiceConfigurationSection)ConfigurationManager.GetSection("serviceConfigs/Service");
            
            url = config.ServiceAddress;

            url = string.Format("{0}/{1}.svc", url, serviceName.Substring(1, serviceName.Length - 1));

            return url;
        }
    }
}