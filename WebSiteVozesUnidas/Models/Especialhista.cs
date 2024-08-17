namespace WebSiteVozesUnidas.Models
{
    public class Especialhista
    {
        public Guid IdEspecialhista { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Especialhidade { get; set; }
        public IEnumerable<AvaliacaoEspecialhista>? AvaliacoesEspecialhistas { get; set; }

    }
}
