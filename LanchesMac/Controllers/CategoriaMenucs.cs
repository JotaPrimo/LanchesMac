using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class CategoriaMenucs : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenucs(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.GetAll.OrderBy(c => c.CategoriaNome);

            return View(categorias);
        }


    }




}
