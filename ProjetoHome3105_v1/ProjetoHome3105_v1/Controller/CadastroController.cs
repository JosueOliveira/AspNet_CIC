using ProjetoHome3105_v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoHome3105_v1.Controller
{
    public class CadastroController
    {
        DataBaseContainer contexto = new DataBaseContainer();

        public void AdicionarLivro(Livros livro)
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

        public void Editar (Livros livro)
        {
            contexto.Entry(livro).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir (Livros livro)
        {
            contexto.Entry(livro).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();
        }
    }
}