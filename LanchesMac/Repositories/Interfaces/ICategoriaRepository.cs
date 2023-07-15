using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll { get; }
    }
}
