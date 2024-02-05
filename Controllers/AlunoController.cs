using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Repositorio;
using System.Collections.Generic;

namespace SistemaDeCadastro.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
            List<AlunoModel> alunos = _alunoRepositorio.BuscarTodos();
            return View(alunos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _alunoRepositorio.Apagar(id);
                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Cadastro do Aluno apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar o cadastrar o Aluno, tente novamente!!!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o Aluno, tente novamente!!! detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(AlunoModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunoRepositorio.Adicionar(aluno);
                    TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(aluno);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o Aluno, tente novamente!!! detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(AlunoModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunoRepositorio.Atualizar(aluno);
                    TempData["MensagemSucesso"] = "Cadastro do Aluno atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Editar", aluno);
            }
            catch (System.Exception error)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar o cadastro do Aluno, tente novamente!!! detalhe do erro: {error.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
