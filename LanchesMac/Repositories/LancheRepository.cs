using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using System.Data.Entity;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _dbContext;

        public LancheRepository(AppDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public IEnumerable<Lanche> GetAll => _dbContext.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> GetPreferidos => _dbContext.Lanches.
                                                    Where(l => l.IslanchePreferido).
                                                    Include(c => c.Categoria);

        public Lanche GetLancheById(int id)
        {
            return _dbContext.Lanches.FirstOrDefault(l => l.Id == id);   
        }
    }

}
