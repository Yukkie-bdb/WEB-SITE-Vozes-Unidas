namespace WebSiteVozesUnidas.Models
{
    public class Post
    {
        public Guid IdPost { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string ImgPost { get; set; }
        public DateTime Horario { get; set; }
        public Guid? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public IEnumerable<Comentario>? Comentarios { get; set; }

    }
}
