using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {          
            // authorze checa se está logado, posso passar o roles tmbm, pelo perfil
            return RedirectToAction("Login", "Account");
        }
    }
}
