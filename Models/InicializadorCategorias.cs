using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmocoApp.Models;

namespace AlmocoApp.Models
{
    class InicializadorCategorias : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var categorias = new List<Categoria>
            {
                new Categoria { CategoriaNome = "Churrasco"},
                new Categoria { CategoriaNome = "Sushi"},
                new Categoria { CategoriaNome = "Buffet"},
                new Categoria { CategoriaNome = "Cachorro Quente"},
                new Categoria { CategoriaNome = "Massas"}
            };
            categorias.ForEach(s => context.Categorias.Add(s));
            context.SaveChanges();
        }
    }
}
