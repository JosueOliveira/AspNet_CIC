using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula0806_MVC.Models
{
    public class Atleta
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Modalidade { get; set; }
        public int Medalhas { get; set; }
    }
}