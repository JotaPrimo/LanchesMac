using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "No máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(100, ErrorMessage = "No máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, string categoriaNome, string descricao)
        {
            Id = id;
            CategoriaNome = categoriaNome;
            Descricao = descricao;
        }


    }


}
