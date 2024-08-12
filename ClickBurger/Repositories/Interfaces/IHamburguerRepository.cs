using ClickBurger.Models;

namespace ClickBurger.Repositories.Interfaces
{
    public interface IHamburguerRepository
    {

        IEnumerable<Hamburguer> Hamburgueres { get; }
        IEnumerable<Hamburguer> HamburgueresPreferidos { get; }
        Hamburguer GetHamburguer(int HamburguerId);

    }
}
