using Aua2505_EF_Model_First.Models;
using System.Collections.Generic;
using System.Linq;

namespace Aua2505_EF_Model_First.Controllers
{
    public class CategoriasController
    {
        DatabaseContainer contexto = new DatabaseContainer();

        public void Adicionar(Categoria categoria)
        {
            contexto.Categorias.Add(categoria);
            contexto.SaveChanges();
        }

        public List<Categoria> Listar()
        {
            return contexto.Categorias.ToList();
        }

        public Categoria LocarlizarPorID(int id)
        {
            //find procura por chave
            return contexto.Categorias.Find(id);
        }

        public void Editar(Categoria categoria)
        {
            //state estado do registro
            //entry entrada
            contexto.Entry(categoria).State = System.Data.Entity.EntityState.Modified;

            contexto.SaveChanges();
        }

        public void Excluir(Categoria categoria)
        {
            contexto.Entry(categoria).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();
        }
    }
}