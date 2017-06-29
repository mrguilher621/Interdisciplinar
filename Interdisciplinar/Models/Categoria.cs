using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interdisciplinar.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public String nome { get; set; }
    }
    public class RootObject
    {
        public List<Categoria> categoria { get; set; }
    }
}