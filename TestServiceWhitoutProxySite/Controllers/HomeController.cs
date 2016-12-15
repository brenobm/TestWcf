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
            ServiceFactoryHelper<ICalculatorService> serviceFactory = new ServiceFactoryHelper<ICalculatorService>();

            ICalculatorService calculator = serviceFactory.GetService();

            CalculatorDataContract data = new CalculatorDataContract();
            data.Operation = OperationType.Addition;
            data.ValueA = 10;
            data.ValueB = 5;

            CalculatorDataContract dataResult = calculator.ExecuteOperation(data);

            ViewBag.Data = dataResult;

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