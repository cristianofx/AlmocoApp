using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AlmocoApp.Models
{
    class DatabaseContext : DbContext
    {

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
