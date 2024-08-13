using ClickBurger.Models;

namespace ClickBurger.ViewModels
{
    public class HamburguerListViewModel
    {
        public IEnumerable<Hamburguer> Hamburguer { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
