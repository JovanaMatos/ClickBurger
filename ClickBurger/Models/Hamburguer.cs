namespace ClickBurger.Models
{
    public class Hamburguer
    {
        public int HamburguerId { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }

        public decimal Preco {  get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnaiUrl { get; set; }
        public bool IsHamburguerPreferido { get; set; }
        public bool EmEstoque { get; set; }


        public int CategoriaId { get; set; } //definindo o relacionamento
        public virtual Categoria Categoria { get; set; }


    }
}
