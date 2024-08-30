namespace WebSiteVozesUnidas.Models
{
    public class CandidatoJornalista
    {
        public Guid IdCandidatoJornalista { get; set; }
        public Guid CandidatoId { get; set; }
        public Candidato? Candidato { get; set; }
    }
}
