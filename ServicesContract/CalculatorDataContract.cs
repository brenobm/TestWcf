using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public class CalculatorDataContract
    {
        public double ValueA { get; set; }
        public double ValueB { get; set; }
        public double Result { get; set; }
        public OperationType Operation { get; set; }
    }

    public enum OperationType
    {
        Addition,
        Subtraction,
        Division,
        Multiplication
    }
}
