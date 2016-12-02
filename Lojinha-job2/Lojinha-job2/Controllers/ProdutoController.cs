using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lojinha_job2.Models;

namespace Lojinha_job2.Controllers
{
    public class ProdutoController : Controller
    {
        private LojinhaDbContext db = new LojinhaDbContext();

        // GET: Produto
        public async Task<ActionResult> Index()
        {
            return View(await db.Produto.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = await db.Produto.FindAsync(id);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produtoModel);
               

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(produtoModel);
        }

        // GET: Produto/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = await db.Produto.FindAsync(id);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(produtoModel);
        }

        // GET: Produto/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = await db.Produto.FindAsync(id);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProdutoModel produtoModel = await db.Produto.FindAsync(id);
            db.Produto.Remove(produtoModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
