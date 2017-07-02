using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelos.Cadastros;
using Persistencia.Context;
using Servicos.Cadastros;

namespace Interdisciplinar.Controllers
{
    public class ItensController : Controller
    {
        #region [Metodos]
        private EFContext db = new EFContext();
        private ItemServicos itemServicos = new ItemServicos();
        private CategoriaServicos categoriaServicos = new CategoriaServicos();

        private ActionResult GetViewItemId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = itemServicos.ById((long)id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        private ActionResult SalveItem(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    itemServicos.Save(item);
                    return RedirectToAction("Index");
                }
                return View(item);
            }
            catch
            {
                return View(item);
            }
        }
        private void PopularViewBag(Item item = null)
        {
            if (item == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServicos.GetOrderedByName(),
                    "CategoriaId", "nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServicos.GetOrderedByName(),
                   "CategoriaId", "nome",item.CategoriaId);
            }
        }

        #endregion [Metodos]

        // GET: Itens
        public ActionResult Index()
        {
           
            return View(itemServicos.GetOrderedByName());
        }

        // GET: Itens/Details/5
        public ActionResult Details(long? id)
        {
           
            return GetViewItemId(id);
        }

        // GET: Itens/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Itens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,nome,CategoriaId")] Item item)
        {
            return SalveItem(item);
        }

        // GET: Itens/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(itemServicos.ById((long)id));
            return GetViewItemId(id);
        }

        // POST: Itens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,nome,CategoriaId")] Item item)
        {
            
            return SalveItem(item);
        }

        // GET: Itens/Delete/5
        public ActionResult Delete(long? id)
        {
            return GetViewItemId(id);
        }

        // POST: Itens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                Item item = itemServicos.Delete(id);
                TempData["Message"] = "Itens" + item.nome.ToUpper() + "Foi Removido";
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
