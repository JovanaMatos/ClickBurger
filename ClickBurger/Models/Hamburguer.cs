using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickBurger.Models
{
    [Table("Hamburgueres")]
    public class Hamburguer
    {
        [Key]
        public int HamburguerId { get; set; }
        [Required(ErrorMessage ="O nome do lanche deve ser informado")]
        [Display (Name = "Nome do Hamburguer")]
        [StringLength(80, MinimumLength =10, ErrorMessage ="O {0} deve ter no minimo {1} e no máximo {2}")] //stringLength permite eu defini a quantidade max e minima
        public string Nome { get; set; }

        
        [Required(ErrorMessage = "A descrição do hamburguer deve ser informada")]
        [Display(Name = "Descrição do Hamburguer")]
        [MinLength(20, ErrorMessage ="Descrição do deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder {1} caracteres")]// usamos o max e min apenas para mostrar que podemos usala-los porem pode ser feito tudo pelo StringLength
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição do hamburguer deve ser informada")]
        [Display(Name = "Descrição do Hamburguer")]
        [MinLength(20, ErrorMessage = "Descrição do deve ter no minimo {1} caracteres")]
        [MaxLength(300, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required (ErrorMessage ="Informe o preço do hamburguer")]
        [Display(Name = "Preço")]
        [Column(TypeName ="decimal (10,2)")]//definindo o tipo e a precisão
        [Range(1,999.99,ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco {  get; set; }

        [Display(Name= "Caminho Imagem miniatura")]
        [StringLength(200, ErrorMessage ="O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnaiUrl { get; set; }

        [Display(Name = "Preferido")]
        public bool IsHamburguerPreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; } //definindo o relacionamento
        public virtual Categoria Categoria { get; set; }


    }
}
