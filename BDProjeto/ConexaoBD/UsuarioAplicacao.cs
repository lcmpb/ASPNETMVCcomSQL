﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConexaoBD
{
    class UsuarioAplicacao
    {
        private bd bd;

        private void Insert(Usuarios usuarios)
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

        private void Update(Usuarios usuarios)
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

        public void Salvar(Usuarios usuarios)
        {
            if (usuarios.Id > 0)
            {
                Update(usuarios);
            }
            else
            {
                Insert(usuarios);
            }

        }

        public void Delete(int id)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format(" DELETE FROM usuarios WHERE usuarioId = {0} ", id);
                bd.ExecutaComando(strQuery);
            }
        }

        public List<Usuarios> ListarTodos()
        {
            using (bd = new bd())
            {
                var strQuery = "SELECT * FROM usuarios ORDER BY usuarioId";
                var retorno = bd.ExecutaComandoComRetorno(strQuery);
                return ReaderEmLista(retorno);
            }
        }


        private List<Usuarios> ReaderEmLista(SqlDataReader reader)
        {
            var usuarios = new List<Usuarios>();

            while (reader.Read())
            {
                var tempoObjeto = new Usuarios()
                {
                    Id = int.Parse(reader["usuarioId"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Cargo = reader["cargo"].ToString(),
                    Date = DateTime.Parse(reader["date"].ToString())
                };

                usuarios.Add(tempoObjeto);
            }

            reader.Close();
            return usuarios;
        }


    }
}
