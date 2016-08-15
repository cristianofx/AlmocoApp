using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AlmocoApp.Models
{
    public class Restaurante
    {

        public int RestauranteID { get; set; }

        [Display(Name = "Nome do Restaurante")]
        public string RestauranteNome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        public Categoria RestauranteCategoria { get; set; }

        [Display(Name = "Faixa de Preço")]
        public Int16 FaixaPreco { get; set; }


    }
}
