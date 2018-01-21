using BDProjeto.Aplicacao;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
            var listaUsuarios = appUsuario.ListarTodos();

            return View(listaUsuarios);
        }

        
    }
}