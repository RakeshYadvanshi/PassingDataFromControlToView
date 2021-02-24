using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PassingDataFromControlToView.Models;
using PassingDataFromControlToView.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PassingDataFromControlToView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService personService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            this.personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PassDataByViewBag()
        {
            var userName = personService.GetUserName();
            ViewBag.UserName = userName;
            return View();
        }

        public IActionResult PassDataByViewData()
        {
            var userName = personService.GetUserName();
            ViewData["UserName"] = userName;
            return View();
        }

        public IActionResult PassDataByTempData()
        {
            var userName = personService.GetUserName();
            TempData["UserName"] = userName;
            return View();

        }

        public IActionResult PassDataByStronglyTypeViewWithWizard()
        {
            var userName = personService.GetUserName();
            var person = new Person();
            person.Name = userName;
            return View(person);
        }

        public IActionResult PassDataByStronglyTypeViewCustom()
        {
            var userName = personService.GetUserName();
            var person = new Person();
            person.Name = userName;
            return View(person);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
