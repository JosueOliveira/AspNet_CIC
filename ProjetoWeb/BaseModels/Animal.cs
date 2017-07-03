﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual Categoria categoria { get; set; }

    }
}
