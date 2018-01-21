using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class AlunoController : Controller
    {
        private UsuarioAplicacao appUsuario; //var global dentro da classe

        public AlunoController()
        {
            appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();
            // appUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoEF();

        }

        // GET: Aluno
        public ActionResult Aluno()
        {
            var listaUsuarios = appUsuario.ListarTodos();

            return View(listaUsuarios);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                appUsuario.Salvar(usuario);
                return RedirectToAction("Aluno");
            }


            return View(usuario);
        }

        public ActionResult Editar(string id)
        {
            var usuario = appUsuario.ListarPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);

        }

        [HttpPost]
        public ActionResult Editar(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                appUsuario.Salvar(usuario);
                return RedirectToAction("Aluno");
            }


            return View(usuario);
        }

        public ActionResult Excluir(string id)
        {
            var usuario = appUsuario.ListarPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(usuario);
            }
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(string id)
        {
            var usuario = appUsuario.ListarPorId(id);
            appUsuario.Delete(usuario);
            return RedirectToAction("Aluno");

        }


        public ActionResult Detalhes(string id)
        {
            var usuario = appUsuario.ListarPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);

        }
    }
}