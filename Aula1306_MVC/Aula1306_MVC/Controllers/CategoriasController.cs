using Aula1306_MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aula1306_MVC.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {

            //usando ViewBag
            //List<string> categorias = new List<string>();
            //categorias.Add("Carros");
            //categorias.Add("Motos");
            //categorias.Add("Barcos");
            //categorias.Add("Caminhoes");
            ////viewBag envia informações para View
            //ViewBag.ListaCategorias = categorias;

            List<Categoria> categorias = new List<Categoria>();

            categorias.Add(new Categoria() { Nome = "Carros" });
            categorias.Add(new Categoria() { Nome = "Motos" });
            categorias.Add(new Categoria() { Nome = "Barcos" });
            categorias.Add(new Categoria() { Nome = "Caminhoes" });

            return View(categorias);
        }
    }
}