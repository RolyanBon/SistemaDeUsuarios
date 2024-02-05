using SistemaDeCadastro.Data;
using SistemaDeCadastro.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeCadastro.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AlunoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public AlunoModel ListarPorId(int id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Id == id);
        }
        public List<AlunoModel> BuscarTodos()
        {
            return _bancoContext.Alunos.ToList();
        }
        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();
            return aluno;
        }

        public AlunoModel Atualizar(AlunoModel aluno)
        {
            AlunoModel alunoDB = ListarPorId(aluno.Id);
            if(alunoDB == null)
            {
                throw new System.Exception("Houve um erro na atualização do Aluno!");
            }

            alunoDB.Matricula = aluno.Matricula;
            alunoDB.Nome = aluno.Nome;
            alunoDB.Curso = aluno.Curso;
            alunoDB.Email = aluno.Email;
            alunoDB.Celular = aluno.Celular;

            _bancoContext.Update(alunoDB);
            _bancoContext.SaveChanges();

            return alunoDB;
        }

        public bool Apagar(int id)
        {
            AlunoModel alunoDB = ListarPorId(id);
            if (alunoDB == null)
            {
                throw new System.Exception("Houve um erro na deleção do Aluno!");
            }
            _bancoContext.Remove(alunoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
