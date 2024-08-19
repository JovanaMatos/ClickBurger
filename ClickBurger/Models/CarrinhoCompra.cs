
using ClickBurger.Context;

using Microsoft.EntityFrameworkCore;


namespace ClickBurger.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _Context;

        public CarrinhoCompra(AppDbContext context)
        {
            _Context = context;
        }

        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //OBTEM OU GERA id do carrinho

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };

        }

        public void AdicionarAoCarrinho(Hamburguer hamburguer)
        {
            var carrinhoCompraItem = _Context.CarrinhoCompraItens.SingleOrDefault(
                     s => s.Hamburguer.HamburguerId == hamburguer.HamburguerId &&
                     s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Hamburguer = hamburguer,
                    Quantidade = 1
                };
                _Context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _Context.SaveChanges();
        }

        public int RemoverDoCarrinho(Hamburguer hamburguer)
        {
            var carrinhoCompraItem = _Context.CarrinhoCompraItens.SingleOrDefault(
                   s => s.Hamburguer.HamburguerId == hamburguer.HamburguerId &&
                   s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _Context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _Context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ??
                   (CarrinhoCompraItems =
                   _Context.CarrinhoCompraItens
                   .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                   .Include(s => s.Hamburguer)
                   .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _Context.CarrinhoCompraItens
                                 .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _Context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _Context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _Context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Hamburguer.Preco * c.Quantidade).Sum();
            return total;
        }





    }



}
