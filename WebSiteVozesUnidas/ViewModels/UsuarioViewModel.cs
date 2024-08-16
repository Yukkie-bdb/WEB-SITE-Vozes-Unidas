using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public UsuarioTipo Tipo { get; set; }

        // Campos específicos para Empresa
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; }
        public string? Descricao { get; set; }

        // Campos específicos para Candidato
        public string? Cpf { get; set; }
    }
}
