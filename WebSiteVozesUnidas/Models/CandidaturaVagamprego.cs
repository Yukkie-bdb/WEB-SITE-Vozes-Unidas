namespace WebSiteVozesUnidas.Models
{
    public class CandidaturaVagamprego
    {
        public Guid IdCandidaturaVagamprego { get; set; }

        // Relacionamento com Usuario (Candidato)
        public Guid CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        // Relacionamento com Vaga de Emprego
        public Guid VagaId { get; set; }
        public VagaEmprego Vaga { get; set; }
    }
}
