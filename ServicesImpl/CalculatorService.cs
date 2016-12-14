using ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImpl
{
    public class CalculatorService : CalculatorServiceContract
    {
        public CalculatorDataContract ExecuteOperation(CalculatorDataContract data)
        {
            if (data == null)
            {
                //throw new ArgumentNullException(nameof(data), $"The parameter ${nameof(data)} can't be null.");
                throw new ArgumentNullException("data", "The parameter \"data\" can't be null.");
            }

            switch(data.Operation)
            {
                case OperationType.Addition:
                    data.Result = data.ValueA + data.ValueB;
                    break;
                case OperationType.Subtraction:
                    data.Result = data.ValueA - data.ValueB;
                    break;
                case OperationType.Multiplication:
                    data.Result = data.ValueA * data.ValueB;
                    break;
                case OperationType.Division:
                    data.Result = data.ValueA / data.ValueB;
                    break;
                default:
                    throw new ArgumentException("The type of operation is invalid.");
            }

            return data;
        }
    }
}
