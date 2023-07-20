using Microsoft.AspNetCore.Mvc;

namespace FinalAirport.Controllers
{
    public class FinalAirportController : Controller
    {
        public IActionResult Flights()
        {
            return View();
        }

        public IActionResult StaffPage()
        {
            return View();
        }
    }
}
