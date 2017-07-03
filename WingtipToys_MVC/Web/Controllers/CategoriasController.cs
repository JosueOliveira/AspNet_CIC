using BaseModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CategoriasController : Controller
    {
        //contexto do banco de dados
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = db.Categorias.ToList();
            //filtro
            //categorias.Where();
            return View(categorias);
        }
        //GET- CADASTAR NOVA CATEGOIRIA   
        //chamando o carregamento da Pagina View      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]//MÉTODO POST - cria categoria
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
                return View(); 
        }

        //Exibição de detalhes do objeto
        //GET
        public ActionResult Details(int? id)
        {
            //não passou id
            if(id == null /*id.Hasvalue*/)
            {
                //errro http 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //
            Categoria categoria = db.Categorias.Find(id);
            //não encontrou
            if(categoria == null)
            {
                //
                return HttpNotFound();
            }
            //encontrou id no banco retorna o objeto para view
            return View(categoria);
        }

        //Eidtar categoria
        //GET 
        public ActionResult Edit(int? id)
        {
            //não passou id
            if (id == null /*id.Hasvalue*/)
            {
                //errro http 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //
            Categoria categoria = db.Categorias.Find(id);
            //não encontrou
            if (categoria == null)
            {
                //erro http 404
                return HttpNotFound();
            }
            //encontrou id no banco retorna o objeto para view
            return View(categoria);
        }
        //Set editar
         [HttpPost] 
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State =
                    System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(categoria);
        }

        //Excluir
        //Get
        public ActionResult Delete(int? id)
        {
            //não passou id
            if (id == null /*id.Hasvalue*/)
            {
                //erro http 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //
            Categoria categoria = db.Categorias.Find(id);
            //não encontrou
            if (categoria == null)
            {
                //
                return HttpNotFound();
            }
            //encontrou id no banco retorna o objeto para view
            return View(categoria);
        }

        //SET
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}