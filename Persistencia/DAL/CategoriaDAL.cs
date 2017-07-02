
using Modelos.Cadastros;
using Persistencia.Context;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Categoria> Get()
        {
            return context
                .Categorias;
        }

        public IQueryable<Categoria> GetOrderedByName()
        {
            return context.Categorias
                .OrderBy(b => b.nome);
        }

        private string GetName(Categoria b)
        {
            if (b. CategoriaId > 0)
                return b.nome;
            return string.Empty;
        }

        public Categoria ById(long id)
        {
            return context
                .Categorias
                .Where(s => s.CategoriaId == id)
                .First();
        }

        public void Save(Categoria item)
        {
            if (item.CategoriaId == 0)
                context.Categorias.Add(item);
            else
                context.Entry(item).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Categoria Delete(long id)
        {
            var item = ById(id);

            context.Categorias.Remove(item);
            context.SaveChanges();

            return item;
        }
    }
}
