using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServicesContract
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        CalculatorDataContract ExecuteOperation(CalculatorDataContract data);
    }
}
