using System.Collections.Generic;

namespace BDProjeto.Dominio.contrato
{
    public interface IRepositorio<T>where T : class
    {
        void Salvar(T entidade);
        void Delete(T entidade);
        IEnumerable<T> ListarTodos();
        T ListarPorId(string id);

    }
}
