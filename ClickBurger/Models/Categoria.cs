namespace ClickBurger.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoriaName { get; set; }
        public string Descricao { get; set; }


        public List<Hamburguer> HamburguerList { get; set; }// definindo um relacionameto de um para muitos com Categoria e Hamburguer
    }
}
