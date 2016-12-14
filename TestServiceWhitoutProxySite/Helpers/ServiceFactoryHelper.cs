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
            ServiceConfigurationSection config = (ServiceConfigurationSection)ConfigurationManager.GetSection("serviceConfigs/" + typeof(TServiceContract).Name);
            return config.ServiceConfig.ServiceAddress;
            
        }
    }
}