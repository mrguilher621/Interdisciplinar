using Modelos.Cadastros;
using System.Data.Entity;

namespace Persistencia.Context
{
    public class EFContext :DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Item> Itens { get; set; }
        
        public EFContext()
        : base("Asp_Net_MVC_CS")
        {
            var dbInit = new DropCreateDatabaseAlways<EFContext>();
            Database.SetInitializer<EFContext>(dbInit);
        }
    }
}