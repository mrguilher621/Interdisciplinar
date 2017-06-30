using Modelos.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelos.Cadastros
{
    public class Categoria
    {
        public long? id { get; set; }
        public String nome { get; set; }

        public virtual ICollection<Item> Itens { get; set; }
    }
    public class RootObject
    {
        public List<Categoria> categoria { get; set; }
    }
}