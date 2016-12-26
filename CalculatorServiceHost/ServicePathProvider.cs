using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CalculatorServiceHost
{
    public class ServicePathProvider : VirtualPathProvider
    {
        public override VirtualFile GetFile(string virtualPath)
        {
            if (!this.IsServiceCall(virtualPath))
                return this.Previous.GetFile(virtualPath);
            return new ServiceFile(virtualPath);
        }

        private bool IsServiceCall(string virtualPath)
        {
            // Check if it is a wcf service call
            virtualPath = VirtualPathUtility.ToAppRelative(virtualPath);
            return (virtualPath.ToLower().StartsWith("~/"));
        }

        public override bool FileExists(string virtualPath)
        {
            if (!this.IsServiceCall(virtualPath))
                return this.Previous.FileExists(virtualPath);
            return true;
        }
    }
}