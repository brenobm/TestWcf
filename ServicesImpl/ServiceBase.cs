using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImpl
{
    public class ServiceBase
    {
        protected WebHeaderCollection headers;

        public ServiceBase()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;

            headers = request.Headers;

            ValidateToken();
        }

        protected void ValidateToken()
        {
            if (headers["AuthToken"] == null)
                throw new UnauthorizedAccessException("Token de autenticação não informado.");

            string authToken = headers["AuthToken"];

            Token token = new Token();

            if(!token.ValidateHash(authToken))
            {
                throw new UnauthorizedAccessException("Token de autenticação inválido.");
            }
        }
    }
}
