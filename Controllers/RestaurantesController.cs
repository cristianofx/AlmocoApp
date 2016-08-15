using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlmocoApp.Models;

namespace AlmocoApp.Controllers
{
    public class RestaurantesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Restaurantes
        public ActionResult Index()
        {
            //pegar as categorias do banco para poder apresentar na tabela por nome em vez de por id
            DatabaseContext _db = new DatabaseContext();
            IList<Categoria> categorias = _db.Categorias.ToList();
            ViewBag.Categorias = categorias;

            return View(db.Restaurantes.ToList());
        }

        // GET: Restaurantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }

            Categoria categoria = db.Categorias.Find(restaurante.CategoriaID);
            ViewBag.CategoriaRestaurante = categoria;

            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public ActionResult Create()
        {
            //Cria a lista de faixas de preço e adiciona na viewbag
            List<SelectListItem> faixas = new List<SelectListItem>();

            faixas.Add(new SelectListItem { Text = "Muito Barato", Value = "1" });
            faixas.Add(new SelectListItem { Text = "Barato", Value = "2" });
            faixas.Add(new SelectListItem { Text = "Médio", Value = "3" });
            faixas.Add(new SelectListItem { Text = "Caro", Value = "4" });
            faixas.Add(new SelectListItem { Text = "Muito Caro", Value = "5" });

            ViewBag.Faixas = faixas;


            //Busca a lista de categorias do banco e adiciona na viewbag
            List<SelectListItem> categorias = new List<SelectListItem>();
            DatabaseContext _db = new DatabaseContext();
            List<Categoria> listaCategorias = _db.Categorias.ToList();
            foreach (var cat in listaCategorias)
            {
                categorias.Add(new SelectListItem { Text = cat.CategoriaNome, Value = cat.CategoriaID.ToString() });
            }

            ViewBag.Categorias = categorias;

            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestauranteID,RestauranteNome,Descricao,Endereco,FaixaPreco")] Restaurante restaurante)
        {
            string valorFaixa = Request.Form["Faixas"].ToString();
            short faixaSelecionada = short.Parse(valorFaixa);
            string categoria = Request.Form["Categorias"].ToString();
            int categoriaID = int.Parse(categoria);

            if (ModelState.IsValid)
            {
                restaurante.CategoriaID = categoriaID;
                restaurante.FaixaPreco = faixaSelecionada;
                db.Restaurantes.Add(restaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> faixasLista = new List<SelectListItem>();

            faixasLista.Add(new SelectListItem { Text = "Muito Barato", Value = "1", Selected = (restaurante.FaixaPreco == 1 ? true : false) });
            faixasLista.Add(new SelectListItem { Text = "Barato", Value = "2", Selected = (restaurante.FaixaPreco == 2 ? true : false) });
            faixasLista.Add(new SelectListItem { Text = "Médio", Value = "3", Selected = (restaurante.FaixaPreco == 3 ? true : false) });
            faixasLista.Add(new SelectListItem { Text = "Caro", Value = "4", Selected = (restaurante.FaixaPreco == 4 ? true : false) });
            faixasLista.Add(new SelectListItem { Text = "Muito Caro", Value = "5", Selected = (restaurante.FaixaPreco == 5 ? true : false) });


            ViewBag.FaixasLista = faixasLista;


            List<SelectListItem> categoriasLista = new List<SelectListItem>();
            DatabaseContext _db = new DatabaseContext();
            List<Categoria> listaCategorias = _db.Categorias.ToList();
            foreach (var cat in listaCategorias)
            {
                int restCat = restaurante.CategoriaID;
                int catCatID = cat.CategoriaID;
                categoriasLista.Add(new SelectListItem { Text = cat.CategoriaNome, Value = cat.CategoriaID.ToString(), Selected = (restCat == catCatID ? true : false) });
            }

            ViewBag.CategoriasLista = categoriasLista;


            return View(restaurante);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestauranteID,RestauranteNome,Descricao,Endereco,FaixaPreco")] Restaurante restaurante)
        {
            string valorFaixa = Request.Form["Faixas"].ToString();
            short faixaSelecionada = short.Parse(valorFaixa);
            string categoria = Request.Form["Categorias"].ToString();
            int categoriaID = int.Parse(categoria);

            if (ModelState.IsValid)
            {
                restaurante.CategoriaID = categoriaID;
                restaurante.FaixaPreco = faixaSelecionada;
                db.Entry(restaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            db.Restaurantes.Remove(restaurante);
            db.SaveChanges();
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
