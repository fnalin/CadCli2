using FanSoft.CadCli.Core.Domain.Enums;
using System.Collections.Generic;

namespace FanSoft.CadCli.Core.Domain.Entities
{
    public class Cliente : Entity
    {
        protected Cliente() { }

        public Cliente(string nome, Sexo sexo)
        {
            Nome = nome;
            Sexo = sexo;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Enums.Sexo Sexo { get; private set; }

        public IEnumerable<Telefone> Telefones { get; private set; } = new List<Telefone>();

    }
}
