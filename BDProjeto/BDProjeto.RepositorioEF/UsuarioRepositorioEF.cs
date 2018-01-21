using System;
using System.Collections.Generic;
using System.Linq;
using BDProjeto.Dominio;
using BDProjeto.Dominio.contrato;

namespace BDProjeto.RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<Usuarios>
    {
        private readonly bd bd;

        public UsuarioRepositorioEF()
        {
            bd = new bd();
        }

        public void Delete(Usuarios entidade)
        {
            var usuarioDelete = bd.usuario.First(x => x.Id == entidade.Id);
            bd.Set<Usuarios>().Remove(usuarioDelete);
            bd.SaveChanges();
        }

        public Usuarios ListarPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return bd.usuario.First(x => x.Id == idInt);
        }

        public IEnumerable<Usuarios> ListarTodos()
        {
            return bd.usuario;
        }

        public void Salvar(Usuarios entidade)
        {
            if (entidade.Id > 0)
            {
                var usuarioAlterar = bd.usuario.First(x => x.Id == entidade.Id);
                usuarioAlterar.Nome = entidade.Nome;
                usuarioAlterar.Cargo = entidade.Cargo;
                usuarioAlterar.Date = entidade.Date;
            }
            else
            {
                bd.usuario.Add(entidade);
            }
            bd.SaveChanges();
        }
    }
}
