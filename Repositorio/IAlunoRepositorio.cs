using SistemaDeCadastro.Models;
using System.Collections.Generic;

namespace SistemaDeCadastro.Repositorio
{
    public interface IAlunoRepositorio
    {
        AlunoModel ListarPorId(int id);
        List<AlunoModel> BuscarTodos();
        AlunoModel Adicionar(AlunoModel aluno);
        AlunoModel Atualizar(AlunoModel aluno);
        bool Apagar(int id);
    }
}
