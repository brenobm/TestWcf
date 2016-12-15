using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace TestServiceWhitoutProxySite.Helpers
{
    public class ServiceFactoryHelper<TServiceContract>
    {
        public TServiceContract GetService()
        {
            ChannelFactory<TServiceContract> factory = null;
            //BasicHttpBinding binding = new BasicHttpBinding();
            WSHttpBinding binding = new WSHttpBinding();
            EndpointAddress address = new EndpointAddress(GetServiceAdress());
            factory = new ChannelFactory<TServiceContract>(binding, address);
            TServiceContract channel = factory.CreateChannel();
            return channel;
        }

        private string GetServiceAdress()
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