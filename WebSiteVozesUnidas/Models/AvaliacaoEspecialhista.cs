namespace WebSiteVozesUnidas.Models
{
    public class AvaliacaoEspecialhista
    {
        public Guid IdAvaliacaoEspecialhis { get; set; }
        public string Descricao { get; set; }
        public int Estrelas { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
