using System;

namespace ProjetoBase.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Perfis { get; set; }

        public bool Ativo { get; set; }
        
        public DateTime DataCadastro { get; set; }

    }
}
