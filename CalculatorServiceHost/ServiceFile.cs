using System.IO;
using System.Web.Hosting;

namespace CalculatorServiceHost
{
    public class ServiceFile : VirtualFile
    {
        public ServiceFile(string virtualPath)
        : base(virtualPath)
        { }

        public string GetCallingServiceName
        {
            get
            {
                // Return class name. srv_hello.svc => hello
                string svcName = base.VirtualPath.Substring(base.VirtualPath.LastIndexOf("/") + 1);
                return svcName.Replace(".svc", string.Empty);
            }
        }

        public string GetService()
        {

            string srv = this.GetCallingServiceName;
            // hello => Hello
            return srv[0].ToString().ToUpper() + srv.Substring(1);
        }

        public override Stream Open()
        {
            var serviceDef = new MemoryStream();
            var defWriter = new StreamWriter(serviceDef);

            // Write host definition
            defWriter.Write("<%@ ServiceHost Language=\"C#\" Debug=\"true\" Service=\"ServicesImpl." 
                + this.GetService() + "\" " +
                "Factory=\"CalculatorServiceHost.DynamicHostFactory\" %>");
            defWriter.Flush();

            serviceDef.Position = 0;
            return serviceDef;
        }
    }
}