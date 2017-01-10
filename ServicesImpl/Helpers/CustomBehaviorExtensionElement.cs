using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImpl.Helpers
{
    public class CustomBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new MyEndPointBehavior();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(MyEndPointBehavior);
            }
        }
    }

}
