using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }

        public void SeedData()
        {
            if (!Categorias.Any())
            {
                var categorias = new Categoria[]
                {
                    new Categoria { Id = 2, CategoriaNome = "Saudavel ", Descricao = "Excepteur sint occaecat cupidatat non proident"},
                    new Categoria { Id = 3, CategoriaNome = "Organico", Descricao = "Sed ut perspiciatis unde omnis iste natus error"},
                    new Categoria { Id = 4, CategoriaNome = "Fora da Academia", Descricao = "Nemo enim ipsam voluptatem quia voluptas"},
                };

                Categorias.AddRange(categorias);
                SaveChanges();
            }

            if (!Lanches.Any())
            {               

                // Popula a tabela de lanches com a categoria correta
                var lanches = new Lanche[]
                {
                    new Lanche
            {
                Nome = "Lanche 1",
                DescricaoCurta = "Descrição curta do Lanche 1",
                DescricaoDetalhada = "Descrição detalhada do Lanche 1",
                Preco = 10.99,
                ImagemUrl = "url-da-imagem-lanche-1",
                ImagemThumbnailUrl = "url-thumbnail-da-imagem-lanche-1",
                IslanchePreferido = true,
                EmEstoque = true,
                CategoriaId = 1,               
            },
            new Lanche
            {
                Nome = "Lanche 2",
                DescricaoCurta = "Descrição curta do Lanche 2",
                DescricaoDetalhada = "Descrição detalhada do Lanche 2",
                Preco = 8.99,
                ImagemUrl = "url-da-imagem-lanche-2",
                ImagemThumbnailUrl = "url-thumbnail-da-imagem-lanche-2",
                IslanchePreferido = false,
                EmEstoque = true,
                CategoriaId = 2,               
            },

                };

                Lanches.AddRange(lanches);
                SaveChanges();
            }
        }

    }
}
