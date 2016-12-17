using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServicesContract
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        string GetBookName(int codeBook);

        [OperationContract]
        string GeBookAuthor(int codeBook);
    }
}
