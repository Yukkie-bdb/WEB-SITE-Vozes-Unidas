using System.ComponentModel.DataAnnotations;

namespace WebSiteVozesUnidas.Models
{
    public class AvaliacaoEspecialhista
    {
        [Display(Name = "IdAvaliacaoEspecialista")]
        public Guid IdAvaliacaoEspecialhis { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public int Estrelas { get; set; }
        public Guid UsuarioId { get; set; }
        [Display(Name = "Usuário")]
        public Usuario? Usuario { get; set; }
        public Guid EspecialhistaId { get; set; }
        [Display(Name = "Especialista")]
        public Especialhista? Especialhista { get; set; }
    }
}
