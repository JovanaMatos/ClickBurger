using ClickBurger.Context;
using ClickBurger.Models;
using ClickBurger.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClickBurger.Repositories

{
    public class HamburguerRepository : IHamburguerRepository
    {
       private readonly AppDbContext _context;
       public HamburguerRepository(AppDbContext contexto)
        {

            _context = contexto;    
        }

        public IEnumerable<Hamburguer> Hamburgueres => _context.Hamburgueres.Include(c=> c.Categoria);

        public IEnumerable<Hamburguer> HamburgueresPreferidos => _context.Hamburgueres.
            Where(l=> l.IsHamburguerPreferido).Include(c => c.Categoria) ;

        public Hamburguer GetHamburguer(int HamburguerId)
        {
          return _context.Hamburgueres.FirstOrDefault(l=> l.HamburguerId == HamburguerId);
        }
    }
}
