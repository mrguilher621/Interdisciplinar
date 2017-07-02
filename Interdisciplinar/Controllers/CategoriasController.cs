using Modelos.Cadastros;
using Persistencia.Context;
using Servicos.Cadastros;
using System.Net;
using System.Web.Mvc;

namespace Interdisciplinar.Controllers
{
    public class CategoriasController : Controller
    {
        #region [Metodos]
        private EFContext db = new EFContext();
        private CategoriaServicos categoriaServico = new CategoriaServicos();

        private ActionResult GetViewCategoriaId(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ById((long)id);
            if(categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        private ActionResult SalveCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.Save(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }
        private void PopularViewBag(Categoria categoria = null)
        {
            if(categoria == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.GetOrderedByName(),
                    "CategoriaId", "nome");
            }
        }

        #endregion [Metodos]
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.GetOrderedByName());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(long? id)
        {
            return GetViewCategoriaId(id);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Categorias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaId,nome")] Categoria categoria)
        {
            return SalveCategoria(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(categoriaServico.ById((long)id));
            return GetViewCategoriaId(id);
        }

        // POST: Categorias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,nome")] Categoria categoria)
        {
            return SalveCategoria(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(long? id)
        {
            return GetViewCategoriaId(id);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.Delete(id);
                TempData["Message"] = "Categoria" + categoria.nome.ToUpper() + "Foi Removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
