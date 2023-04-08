using Microsoft.AspNetCore.Mvc;

namespace UI.BrazilianAddressCode.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
