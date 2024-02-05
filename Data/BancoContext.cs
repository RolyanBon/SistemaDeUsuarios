using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Models;
using System.Data.Common;

namespace SistemaDeCadastro.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
