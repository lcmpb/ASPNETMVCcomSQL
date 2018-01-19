using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    class UsuarioAplicacao
    {
        private bd bd;

        public void Insert(Usuarios usuarios)
        {
            var strQuery = "";
            strQuery += "INSERT INTO usuarios(nome, cargo, date)";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}')", usuarios.Nome, usuarios.Cargo, usuarios.Date
                );
            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Update(Usuarios usuarios)
        {
            var strQuery = "";
            strQuery += "UPDATE usuarios SET ";
            strQuery += string.Format("nome = '{0}',", usuarios.Nome);
            strQuery += string.Format("cargo = '{0}',", usuarios.Cargo);
            strQuery += string.Format("date = '{0}'", usuarios.Date);
            strQuery += string.Format(" WHERE usuarioId = '{0}'", usuarios.Id);

            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        //CONTINUAR_AULA22
        public void Salvar()
        {

        }


    }
}
