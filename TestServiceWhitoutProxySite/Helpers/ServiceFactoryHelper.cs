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
    public class ServiceFactoryHelper<TServiceContract>
    {
        public TServiceContract GetService()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };


            var store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var cert = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, "CN=RootTestCertificateWCFClient", false)[0];
            store.Close();

            var endpointIdentity = EndpointIdentity.CreateX509CertificateIdentity(cert);
            
            ChannelFactory<TServiceContract> factory = null;
            WSHttpBinding binding = new WSHttpBinding();
            
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            
            
            EndpointAddress address = new EndpointAddress(new Uri(GetServiceAdress()), endpointIdentity);
            //EndpointAddress address = new EndpointAddress(new Uri(GetServiceAdress()));

            //ClientCredentials.ClientCertificate.Certificate

            factory = new ChannelFactory<TServiceContract>(binding, address);
            factory.Credentials.ClientCertificate.Certificate = cert;

            //ClientCredentials credentials = new ClientCredentials();
            ////credentials.ServiceCertificate.Authentication.CertificateValidationMode =
            ////        X509CertificateValidationMode.None;

            //factory.Endpoint.Behaviors.Remove<ClientCredentials>();
            //factory.Endpoint.Behaviors.Add(credentials);

            TServiceContract channel = factory.CreateChannel();

            //ServicePointManager.ServerCertificateValidationCallback =
            //        delegate(object s, X509Certificate certificate,
            //                 X509Chain chain, SslPolicyErrors sslPolicyErrors)
            //        { return true; };

            
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