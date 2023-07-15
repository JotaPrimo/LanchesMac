using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> GetAll { get; }
        IEnumerable<Lanche> GetPreferidos { get; }
        Lanche GetLancheById(int id);
    }
}
