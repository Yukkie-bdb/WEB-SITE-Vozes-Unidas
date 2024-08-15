﻿using Microsoft.EntityFrameworkCore;

namespace WebSiteVozesUnidas.Models
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public UsuarioTipo Tipo { get; set; }

    }
    public enum UsuarioTipo
    {
        Empresa,
        Candidato
    }

    /////

    public class Empresa : Usuario
    {
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }

    }

    public class Candidato : Usuario
    {
        public string Cpf { get; set; }

    }
}