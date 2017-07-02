using Modelos.Cadastros;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
   public class ItemDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Item> Get()
        {
            return context.Itens;
        }

        public IQueryable<Item> GetOrderedByName()
        {
            return context
                .Itens
                .Include(p => p.Categoria)
                .OrderBy(b => b.nome);
        }

        public Item ById(long id)
        {
            return context.Itens
                .Where(p => p.ItemId == id)
                .Include(c => c.Categoria)
                .First();
        }

        public IQueryable<Item> GetByCategory(long categoriaId)
        {
            return context
                .Itens
                .Where(p => p.ItemId.HasValue &&
                p.CategoriaId.Value == categoriaId);
        }

        public void Save(Item item)
        {
            if (item.ItemId == null)
                context.Itens.Add(item);
            else
                context.Entry(item).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Item Delete(long id)
        {

            Item item = ById(id);
            context.Itens.Remove(item);
            context.SaveChanges();

            return item;
        }
    }
}
