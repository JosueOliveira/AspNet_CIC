using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Petbook.Models
{
    public class Categorias
    {
        [Key]
        public int IdCat { get; set; }
        public string Nome { get; set; }
    }
}