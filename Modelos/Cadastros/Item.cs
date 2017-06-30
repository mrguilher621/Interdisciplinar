namespace Modelos.Cadastros
{
    public class Item
    {
        public long? Id { get; set; }

        public string nome { get; set; }

        public long? categoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
