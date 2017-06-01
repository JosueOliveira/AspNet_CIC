using ProjetoHome3105_v2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoHome3105_v2.Controller
{
    public class LivroController
    {
        DataBaseLContainer contexto = new DataBaseLContainer();


        public void Adicionarlivro (Livros livro)
        {
            contexto.Livros.Add(livro);
            contexto.SaveChanges();
        }

        public List<Livros> Listar()
        {
            return contexto.Livros.ToList();
        }

        public Livros LocalizarLivroPorId(int id)
        {
            return contexto.Livros.Find(id);
        }

        public void Editar(Livros livro)
        {
            //state estado do registro
            //entry entrada
            contexto.Entry(livro).State = System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public void Excluir(Livros livro)
        {
            contexto.Entry(livro).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();
        }
    }
}