using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    class Program
    {
        static void Main(string[] args)
        {

            var bd = new bd();
            var usuarioAplicacao = new UsuarioAplicacao();
            
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cargo: ");
            string cargo = Console.ReadLine();
            Console.Write("Data: ");
            string date = Console.ReadLine();
            
            var usuarios = new Usuarios
            {
                Nome = nome,
                Cargo = cargo,
                Date = DateTime.Parse(date)
            };
            usuarios.Id = 1;
            usuarioAplicacao.Update(usuarios);
            usuarioAplicacao.Insert(usuarios);

            string strQuerySelect = "SELECT * FROM usuarios ORDER BY usuarioId";
            SqlDataReader dados = bd.ExecutaComandoComRetorno(strQuerySelect);
            while (dados.Read())
            {
                Console.WriteLine("Id:{0} Nome:{1} Cargo:{2} Data:{3}", dados["usuarioId"], dados["nome"], dados["cargo"], dados["date"]);
            }




        }
    }
}
