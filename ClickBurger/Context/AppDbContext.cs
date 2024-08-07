using ClickBurger.Models;
using Microsoft.EntityFrameworkCore;
namespace ClickBurger.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Hamburguer> Hamburgueres { get; set; }
    }

}
