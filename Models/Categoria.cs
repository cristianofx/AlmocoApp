using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AlmocoApp.Models
{
    public class Categoria
    {

        public int CategoriaID { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

    }
}
