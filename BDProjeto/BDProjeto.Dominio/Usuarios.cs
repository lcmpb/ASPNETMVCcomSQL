using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.Dominio
{
    public class Usuarios
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Insira o nome.")]
        public string Nome { get; set; }
        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Insira o cargo.")]
        public string Cargo { get; set; }
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Insira a data.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

    }
}
