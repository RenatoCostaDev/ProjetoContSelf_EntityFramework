using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoDadosProjeto.Aplicacao;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var appFuncionario = new FuncionarioAplicacao();
            var listaFuncionarios = appFuncionario.ListarTodos();
            return View(listaFuncionarios);
        }        
    }
}
/*public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/