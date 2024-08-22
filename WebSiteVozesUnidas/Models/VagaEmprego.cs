namespace WebSiteVozesUnidas.Models
{
    public class VagaEmprego
    {
        public Guid IdVagaEmprego { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Requisitos { get; set; }
        public DateTime DataPublicacao { get; set; }

        // Relacionamento com Empresa
        public Guid EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }

        // Relacionamento com Candidaturas
        public IEnumerable<CandidaturaVagamprego>? CandidaturaVagampregos { get; set; }
    }
}
