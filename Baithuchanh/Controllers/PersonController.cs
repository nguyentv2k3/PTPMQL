using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
namespace Baithuchanh.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}