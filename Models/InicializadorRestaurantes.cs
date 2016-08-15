using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmocoApp.Models
{
    class InicializadorRestaurantes : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var restaurantes = new List<Restaurante>
            {
                new Restaurante { RestauranteNome = "Churras Cão", Descricao = "Boa carne" , Endereco = "Av. Ipiranga, 55455" , FaixaPreco = 3 , CategoriaID = 1},
                new Restaurante { RestauranteNome = "Sushi Do Japa", Descricao = "Sushi e Temaki" , Endereco = "Av. Bento Gonçalves, 1250" , FaixaPreco = 5 , CategoriaID = 2},
                new Restaurante { RestauranteNome = "Rosinha Buffet", Descricao = "Buffet Honesto" , Endereco = "Av. Bento Gonçalves, 6600" , FaixaPreco = 1 , CategoriaID = 3},
                new Restaurante { RestauranteNome = "Cachorro do Dogão", Descricao = "Cachorro completo" , Endereco = "Av. Ipiranga, 5165" , FaixaPreco = 1 , CategoriaID = 4},
                new Restaurante { RestauranteNome = "Italianíssimo Massas", Descricao = "Todo tipo de massa italiana." , Endereco = "Av. Ipiranga, 8849" , FaixaPreco = 4 , CategoriaID = 5},
                new Restaurante { RestauranteNome = "Bom Apetite", Descricao = "Buffet completo com carnes boas" , Endereco = "Av. Bento Gonçalves, 5546" , FaixaPreco = 2 , CategoriaID = 3},
                new Restaurante { RestauranteNome = "Pastel Pereira", Descricao = "Pasteis de vento." , Endereco = "Av. Bento Goncalves, 5464" , FaixaPreco = 1 , CategoriaID = 4},
            };
            restaurantes.ForEach(s => context.Restaurantes.Add(s));
            context.SaveChanges();
        }
    }
}
