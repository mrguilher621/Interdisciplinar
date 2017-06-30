using Modelos.Cadastros;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos.Cadastros
{
   public class ItemServicos
    {
        private ItemDAL dal = new ItemDAL();

        #region [ Get's ]

        public IQueryable<Item> Get()
        { return dal.Get(); }

        public IQueryable<Item> GetOrderedByName()
        { return dal.GetOrderedByName(); }

        public Item ById(long id)
        { return dal.ById(id); }

        #endregion [ Get's ]

        public void Save(Item item)
        { dal.Save(item); }

        public Item Delete(long id)
        { return dal.Delete(id); }
    }
}
