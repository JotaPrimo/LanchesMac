using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lance")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string DescricaoCurta { get; set; }


        [Required(ErrorMessage = "A descrição Detalhada do lanche deve ser informado")]
        [Display(Name = "Descrição Detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição Detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição Detalhada deve ter no máximo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "O preco Detalhada do lanche deve ser informado")]
        [Display(Name = "Preco")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public string Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no mínimo {1}  caracteres")]
        public string ImagemUrl { get; set; }


        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no mínimo {1}  caracteres")]
        public string ImagemThumbnailUrl { get; set; }


        [Display(Name = "Lanche Preferido ?")]
        public bool IslanchePreferido { get; set; }

        [Display(Name = "Lanche Preferido ?")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }

        public virtual DateTime DataDeCriacao { get; set; }

        [NotMapped]
        public virtual Categoria Categoria { get; set; }
    }
}
