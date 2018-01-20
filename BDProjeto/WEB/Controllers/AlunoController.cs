﻿using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Aluno()
        {
            var appUsuario = new UsuarioAplicacao();
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
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Salvar(usuario);
                return RedirectToAction("Aluno");
            }


            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var appUsuario = new UsuarioAplicacao();
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
                var appUsuario = new UsuarioAplicacao();
                appUsuario.Salvar(usuario);
                return RedirectToAction("Aluno");
            }


            return View(usuario);
        }

        public ActionResult Excluir(int id)
        {
            var appUsuario = new UsuarioAplicacao();
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
        public ActionResult ExcluirConfirmado(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            appUsuario.Delete(id);
            return RedirectToAction("Aluno");

        }


        public ActionResult Detalhes(int id)
        {
            var appUsuario = new UsuarioAplicacao();
            var usuario = appUsuario.ListarPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);

        }
    }
}