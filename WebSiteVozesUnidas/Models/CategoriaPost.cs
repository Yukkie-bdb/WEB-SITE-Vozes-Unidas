namespace WebSiteVozesUnidas.Models
{
    public class CategoriaPost
    {
        public Guid IdCategoriaPost { get; set; }
        public string Categoria { get; set; }
        public IEnumerable<Post>? Posts { get; set; }

    }
}
