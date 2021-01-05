using CGI.ParkingLot.ConsoleApp.DTO;
using CGI.ParkingLot.ConsoleApp.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Customer()
        {
            CustomerService service = new CustomerService();
            List<CustomerDTO> customers = service.SearchCustomers("");
            return View(customers);
        }

        public ActionResult Transaction(int customerID)
        {
            CustomerService service = new CustomerService();
            List<TransactionDTO> transactions = service.GetCustomerTransactions(new CustomerDTO { CustomerID = customerID});
            
            return View(transactions);
        }
    }
}