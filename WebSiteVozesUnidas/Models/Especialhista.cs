using System.ComponentModel.DataAnnotations;

namespace WebSiteVozesUnidas.Models
{
    public class Especialhista
    {
        public Guid IdEspecialhista { get; set; }
        [Display(Name = "Imagem")]
        public string? ImgEspecialista { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Especialidade")]
        public string Especialhidade { get; set; }
        public IEnumerable<AvaliacaoEspecialhista>? AvaliacoesEspecialhistas { get; set; }

        public Usuario Usuario { get; set; }

    }
}
