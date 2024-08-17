namespace WebSiteVozesUnidas.Models
{
    public class CategoriaMaterial
    {
        public Guid IdCategoriaMaterial { get; set; }
        public string Categoria {  get; set; }
        public IEnumerable<MaterialDidatico>? MaterialDidaticos { get; set; }
    }
}
