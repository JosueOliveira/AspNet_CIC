using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetBook.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string NomePet { get; set; }
        public int IdadePet { get; set; }
        public string DonoPet { get; set; }
        public bool Ativo { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria _Categoria { get; set; }



    }
}