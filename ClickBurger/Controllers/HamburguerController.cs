using ClickBurger.Repositories.Interfaces;
using ClickBurger.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClickBurger.Controllers
{
    public class HamburguerController : Controller
    {
        private readonly IHamburguerRepository _hamburguerRepository;

        public HamburguerController(IHamburguerRepository hamburguerRepository)
        {
            _hamburguerRepository = hamburguerRepository;
        }

        public IActionResult List()
            
        {
            var hamburguerListViewModel = new HamburguerListViewModel();
            hamburguerListViewModel.Hamburguer = _hamburguerRepository.Hamburgueres;
            hamburguerListViewModel.CategoriaAtual = "CATEGORIA ATUAL";
            return View(hamburguerListViewModel);
            //var hamburguer = _hamburguerRepository.Hamburgueres;
            //return View(hamburguer);
        }
    }
}
