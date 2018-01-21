using BDProjeto.Dominio;
using BDProjeto.Dominio.contrato;
using BDProjeto.RepositorioADO;
using System.Collections.Generic;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly IRepositorio<Usuarios> repositorio;

        //ctor + tab/tab
        public UsuarioAplicacao(IRepositorio<Usuarios>repo)
        {
            //repositorio = new UsuarioAplicacaoADO(); //instanciado
            repositorio = repo;
        }        

        public void Salvar(Usuarios usuarios)
        {
            repositorio.Salvar(usuarios);

        }

        public void Delete(Usuarios usuario)
        {
            repositorio.Delete(usuario);
        }

        public IEnumerable<Usuarios> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Usuarios ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
