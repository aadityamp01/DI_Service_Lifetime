using DI_Service_Lifetime.Models;
using DI_Service_Lifetime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_Service_Lifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScopedService _scoped1;
        private readonly IScopedService _scoped2;
       
        private readonly ISingletonService _singleton1;
        private readonly ISingletonService _singleton2;
        
        private readonly ITransientService _transient1;
        private readonly ITransientService _transient2;

        //private readonly ILogger<HomeController> _logger;

        public HomeController(
            IScopedService scoped1, 
            IScopedService scoped2,
            ISingletonService singleton1,
            ISingletonService singleton2,
            ITransientService transient1,
            ITransientService transient2
            )
        {   
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _transient1 = transient1;
            _transient2 = transient2;
            
        }

        public IActionResult Index()
        {
            StringBuilder messages = new();
            messages.AppendLine("Transient 1: " + _transient1.GetGuid());
            messages.AppendLine("Transient 1: " + _transient2.GetGuid());
            messages.AppendLine("Scoped 1: " + _scoped1.GetGuid());
            messages.AppendLine("Scoped 2: " + _scoped2.GetGuid());
            messages.AppendLine("Singleton 1: " + _singleton1.GetGuid());
            messages.AppendLine("Singleton 2: " + _singleton2.GetGuid());
            
            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
