using Microsoft.AspNetCore.Mvc;
using ClickBurger.Repositories.Interfaces;
using ClickBurger.Models;
using ClickBurger.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ClickBurger.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IHamburguerRepository _hamburguerRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IHamburguerRepository hamburguerRepository,
            CarrinhoCompra carrinhoCompra)
        {
            _hamburguerRepository = hamburguerRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int hamburguerId)
        {
            var hamburguerSelecionado = _hamburguerRepository.Hamburgueres
                                    .FirstOrDefault(p => p.HamburguerId == hamburguerId);

            if (hamburguerSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(hamburguerSelecionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize]//apenas users logados
        public IActionResult RemoverItemDoCarrinhoCompra(int hamburguerId)
        {
            var hamburguerSelecionado = _hamburguerRepository.Hamburgueres
                                    .FirstOrDefault(p => p.HamburguerId == hamburguerId);

            if (hamburguerSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(hamburguerSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}

