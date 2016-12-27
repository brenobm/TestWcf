using ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImpl
{
    public class BookService : ServiceBase, IBookService
    {
        public string GeBookAuthor(int codeBook)
        {
            return string.Format("Book {0}", codeBook);
        }

        public string GetBookName(int codeBook)
        {
            return string.Format("Author {0}", codeBook);
        }
    }
}
