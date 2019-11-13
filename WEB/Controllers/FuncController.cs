using BancoDadosProjeto.Aplicacao;
using BancoDadosProjeto.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class FuncController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            var appFuncionario = new FuncionarioAplicacao();
            var listaFuncionarios = appFuncionario.ListarTodos();
            return View(listaFuncionarios);
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Funcionarios funcionario)
        {
            if (ModelState.IsValid)
            {
                var appFuncionario = new FuncionarioAplicacao();
                appFuncionario.Salvar(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public ActionResult Editar(int codFuncionario)
        {
            var appFuncionario = new FuncionarioAplicacao();
            var funcionario =  appFuncionario.ListarPorId(codFuncionario);
            if (funcionario== null)
            {
                return HttpNotFound();
            }
            return View (funcionario);
        }

        public ActionResult Editar(Funcionarios funcionario)
        {
            if (ModelState.IsValid)
            {
                var appFuncionario = new FuncionarioAplicacao();
                appFuncionario.Salvar(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
    }
}