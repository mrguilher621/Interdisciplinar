using Modelos.Cadastros;
using Persistencia.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Servicos.Cadastros
{
    public class CategoriaServicos
    {
        private CategoriaDAL dal = new CategoriaDAL();

        #region [ Get's ]

        public IQueryable<Categoria> Get()
        { return dal.Get(); }

        public IEnumerable<Categoria> GetOrderedByName()
        { return dal.GetOrderedByName(); }

        public Categoria ById(long id)
        { return dal.ById(id); }

        #endregion [ Get's ]

        public void Save(Categoria item)
        { dal.Save(item); }

        public Categoria Delete(long id)
        { return dal.Delete(id); }
    }
}
