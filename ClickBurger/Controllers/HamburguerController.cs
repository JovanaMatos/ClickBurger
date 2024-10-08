﻿using ClickBurger.Models;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Hamburguer> hamburguer;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                hamburguer = _hamburguerRepository.Hamburgueres.OrderBy(l => l.HamburguerId);
                categoriaAtual = "Todos os Hamburgueres";
            }
            else
            {

                hamburguer = _hamburguerRepository.Hamburgueres
                          .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                          .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }

            var hamburguerListViewModel = new HamburguerListViewModel
            {
                Hamburguer = hamburguer,
                CategoriaAtual = categoriaAtual
            };

            return View(hamburguerListViewModel);
        }
        public IActionResult Details(int hamburguerId)
        {
            var hamburguer = _hamburguerRepository.Hamburgueres.FirstOrDefault(l => l.HamburguerId == hamburguerId);
            return View(hamburguer);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Hamburguer> hamburguer;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                hamburguer = _hamburguerRepository.Hamburgueres.OrderBy(p => p.HamburguerId);
                categoriaAtual = "Todos os Hamburgueres";
            }
            else
            {
                hamburguer = _hamburguerRepository.Hamburgueres
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (hamburguer.Any())
                    categoriaAtual = "Hamburgueres";
                else
                    categoriaAtual = "Nenhum hamburguer foi encontrado";
            }

            return View("~/Views/Hamburguer/List.cshtml", new HamburguerListViewModel
            {
                Hamburguer = hamburguer,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
