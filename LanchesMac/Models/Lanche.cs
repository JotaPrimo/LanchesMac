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
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(5)]
        [MaxLength(200)]
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public string Preco { get; set; }
        public string ImagemUrl { get; set; }

        public string ImagemThumbnailUrl { get; set; }

        public bool IslanchePreferido { get; set; }

        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }

        public virtual DateTime DataDeCriacao { get; set; }

        [NotMapped]
        public virtual Categoria Categoria { get; set; }
    }
}
