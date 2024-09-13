namespace WebSiteVozesUnidas.Models
{
    public class Noticia
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Resumo { get; set; }

        public string? ImgCapa { get; set; }
        public DateOnly Publicacao { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
