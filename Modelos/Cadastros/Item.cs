namespace Modelos.Cadastros
{
    public class Item
    {
        public long? ItemId { get; set; }

        public string nome { get; set; }

        public long? CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
