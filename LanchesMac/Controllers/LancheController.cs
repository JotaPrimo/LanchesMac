using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _repository;

        public LancheController(ILancheRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            // var lanches = _repository.GetAll;

            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _repository.GetAll;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lancheListViewModel);
        }

    }
}
