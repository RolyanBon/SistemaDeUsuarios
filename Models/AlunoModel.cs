using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastro.Models
{
    public class AlunoModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a Matrícula")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Curso")]
        public string Curso { get; set; }
        [Required(ErrorMessage = "Digite o E-mail")]
        [EmailAddress(ErrorMessage ="O E-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular")]
        [Phone(ErrorMessage ="O Celular informado não é válido!")]
        public string Celular { get; set; }

    }
}
