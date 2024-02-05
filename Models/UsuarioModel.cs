using Microsoft.VisualBasic;
using SistemaDeCadastro.Enums;
using System;

namespace SistemaDeCadastro.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
