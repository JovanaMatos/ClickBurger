using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickBurger.Models
{
    [Table("Categorias")]//Apesar de não ser necessário mais, defino que a class será mapeada para tabela Categorias
    public class Categoria
    {
        [Key]//reforçando que será nossa key msm sabendo que a palabra ID por conveção ja se entende que será a chave
        public int CategoriaId { get; set; }
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]//aqui defino o tamanho max com uma msg de erro
        [Required(ErrorMessage = "Informe o nome da categoria")]//definindo que este campo seja obrigatório e not null no campo
        [Display(Name = "Nome")]//apliquei para exibir o atributo nome
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 100 caracteres")]//aqui defino o tamanho max com uma msg de erro
        [Required(ErrorMessage = "Informe a descrição da categoria")]//definindo que este campo seja obrigatório e not null no campo
        [Display(Name = "Nome")]//apliquei para exibir o atributo nome
        public string Descricao { get; set; }


        public List<Hamburguer> HamburguerList { get; set; }// definindo um relacionameto de um para muitos com Categoria e Hamburguer
    }
}
