using Interdisciplinar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Interdisciplinar.Context
{
    public class EFContext :DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        
        public EFContext()
        : base("Asp_Net_MVC_CS")
        {
            var dbInit = new DropCreateDatabaseIfModelChanges<EFContext>();
            Database.SetInitializer<EFContext>(dbInit);
        }
    }
}