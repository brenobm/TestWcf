using ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestServiceWhitoutProxySite.Helpers;

namespace TestServiceWhitoutProxySite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ICalculatorService calculator = ServiceFactoryHelper<ICalculatorService>.GetService();

            CalculatorDataContract data = new CalculatorDataContract();
            data.Operation = OperationType.Addition;
            data.ValueA = 10;
            data.ValueB = 5;

            CalculatorDataContract dataResult = calculator.ExecuteOperation(data);

            IBookService book = ServiceFactoryHelper<IBookService>.GetService();

            ViewBag.Data = dataResult;
            ViewBag.BookName = book.GetBookName(3);
            ViewBag.AuthorName = book.GeBookAuthor(3);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}