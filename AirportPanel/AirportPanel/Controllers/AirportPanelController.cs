using Microsoft.AspNetCore.Mvc;

namespace AirportPanel.Controllers
{
    public class AirportPanelController : Controller
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
