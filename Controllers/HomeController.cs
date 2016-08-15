using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlmocoApp.Models;

namespace AlmocoApp.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {

            List<SelectListItem> faixasLista = new List<SelectListItem>();

            faixasLista.Add(new SelectListItem { Text = "Todas", Value = "0", Selected = true });
            faixasLista.Add(new SelectListItem { Text = "Muito Barato", Value = "1" });
            faixasLista.Add(new SelectListItem { Text = "Barato", Value = "2" });
            faixasLista.Add(new SelectListItem { Text = "Médio", Value = "3" });
            faixasLista.Add(new SelectListItem { Text = "Caro", Value = "4" });
            faixasLista.Add(new SelectListItem { Text = "Muito Caro", Value = "5" });


            ViewBag.FaixasLista = faixasLista;


            List<SelectListItem> categoriasLista = new List<SelectListItem>();
            DatabaseContext _db = new DatabaseContext();
            List<Categoria> listaCategorias = _db.Categorias.ToList();
            categoriasLista.Add(new SelectListItem { Text = "Todas", Value = "0", Selected = true });
            foreach (var cat in listaCategorias)
            {
                int catCatID = cat.CategoriaID;
                categoriasLista.Add(new SelectListItem { Text = cat.CategoriaNome, Value = cat.CategoriaID.ToString() });
            }

            ViewBag.CategoriasLista = categoriasLista;

            if (Request.HttpMethod == "POST")
            {
                string valorFaixa = Request.Form["Faixas"].ToString();
                int FaixaPrecoParametro = int.Parse(valorFaixa);
                string categoria = Request.Form["Categorias"].ToString();
                int CategoriaParametro = int.Parse(categoria);

                List<Restaurante> restaurantes = null;

                if (CategoriaParametro > 0 && FaixaPrecoParametro > 0)
                {
                    restaurantes = db.Restaurantes.Where(r => r.CategoriaID == CategoriaParametro && r.FaixaPreco == FaixaPrecoParametro).ToList();
                }
                else if (CategoriaParametro > 0 && FaixaPrecoParametro == 0)
                {
                    restaurantes = db.Restaurantes.Where(r => r.CategoriaID == CategoriaParametro).ToList();
                }
                else if (CategoriaParametro == 0 && FaixaPrecoParametro > 0)
                {
                    restaurantes = db.Restaurantes.Where(r => r.FaixaPreco == FaixaPrecoParametro).ToList();
                }
                else
                {
                    restaurantes = db.Restaurantes.ToList();
                }

                Restaurante restaurante = null;

                if (restaurantes.Count > 0)
                {
                    Random rnd = new Random();
                    int valorAleatorio = rnd.Next(0, restaurantes.Count);
                    restaurante = restaurantes.ElementAt(valorAleatorio);
                }

                ViewBag.RestauranteEscolhido = restaurante;
            }

            IList<Categoria> categorias = db.Categorias.ToList();
            ViewBag.Categorias = categorias;


            return View();
        }

        public ActionResult Sobre()
        {

            return View();
        }


    }
}