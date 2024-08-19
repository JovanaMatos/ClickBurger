using ClickBurger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClickBurger.Repositories.Interfaces;

using ClickBurger.ViewModels;

namespace ClickBurger.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IHamburguerRepository _hamburguerRepository;

        public HomeController(IHamburguerRepository hamburguerRepository)
        {
            _hamburguerRepository = hamburguerRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                HamburguersPreferido = _hamburguerRepository.HamburgueresPreferidos
            };

   
            return View(homeViewModel);
        }

 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
