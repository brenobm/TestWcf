using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace TestServiceWhitoutProxySite.Helpers
{
    public class ClientMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            //Nothing here
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            HttpRequestMessageProperty property = null;

            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
                property = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

            if(property == null)
            {
                property = new HttpRequestMessageProperty();
                request.Properties.Add(HttpRequestMessageProperty.Name, property);
            }

            Token token = new Token();

            property.Headers["AuthToken"] = token.GenerateHash();
            property.Headers["IdTeste"] = "Teste123";
            return false;
        }
    }
}
