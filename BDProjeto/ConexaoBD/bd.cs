using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConexaoBD
{
    class bd : IDisposable
    {
        //disposable, serve para quando a classe for 
        //executada sempre que é chamado força o metodo
        //dispose

        private readonly SqlConnection conexao;
        
        public bd()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComandoSelect = new SqlCommand(strQuery, conexao);

            return cmdComandoSelect.ExecuteReader();
        }


        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
