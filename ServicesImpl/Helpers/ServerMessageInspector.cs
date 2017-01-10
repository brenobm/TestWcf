using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ServicesImpl.Helpers
{
    public class ServerMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var prop = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            HttpContext.Current.Session["IdTeste"] = prop.Headers["IdTeste"];

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //Nothing to do here
        }
    }

    public class MyEndPointBehavior : IEndpointBehavior
    {
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new ServerMessageInspector());
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            //Nothing to do here
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            //Nothing to do here
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //Nothing to do here
        }
    }

    public class MyContractBehavior : IContractBehavior
    {

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.MessageInspectors.Add(new ServerMessageInspector());
        }


        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            //Nothing to do here
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            //Nothing to do here
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            //Nothing to do here
        }
    }

}