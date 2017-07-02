using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Petbook.Models
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Dono { get; set; }

        [ForeignKey("_Categoria")]
        public int CategoriaID { get; set; }
        public Categorias _Categoria { get; set; }
    }
}