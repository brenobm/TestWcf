using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TestServiceWhitoutProxySite.Helpers
{
    public class ServiceConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("serviceConfig")]
        public ServiceConfigurationElement ServiceConfig
        {
            get
            {
                return (ServiceConfigurationElement)this["serviceConfig"];
            }
            set
            {
                this["serviceConfig"] = value;
            }
        }
    }

    public class ServiceConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("serviceName", IsRequired = true)]
        public string ServiceName
        {
            get
            {
                return (String)this["serviceName"];
            }
            set
            {
                this["serviceName"] = value;
            }
        }

        [ConfigurationProperty("serviceAddress", IsRequired = true)]
        public string ServiceAddress
        {
            get
            {
                return (String)this["serviceAddress"];
            }
            set
            {
                this["serviceAddress"] = value;
            }
        }
    }
}