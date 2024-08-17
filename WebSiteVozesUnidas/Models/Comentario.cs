namespace WebSiteVozesUnidas.Models
{
    public class Comentario
    {
        public Guid IdComentario { get; set; }
        public string Conteudo { get; set; }
        public Guid? PostId { get; set; }
        public Post? Post { get; set; }
        public Guid? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
