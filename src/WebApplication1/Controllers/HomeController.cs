using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Salvar(Frota frota)
        {
            var listVeiculos = frota.Veiculos;

            return Json(new { Result = "Conversão OK" });
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
