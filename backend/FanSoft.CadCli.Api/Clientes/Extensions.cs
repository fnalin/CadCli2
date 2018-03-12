using Entities = FanSoft.CadCli.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FanSoft.CadCli.Api.Clientes
{
    public static class Extensions
    {

        public static IEnumerable<ClienteGetVM> ToVM(this IEnumerable<Entities.Cliente> data)
        {
            return data.Select(d => new ClienteGetVM
            {
                Id = d.Id,
                Nome = d.Nome,
                Tels = d.Telefones.Select(t=>t.Numero),
                Sexo = Enum.GetName(typeof(Core.Domain.Enums.Sexo), d.Sexo)
            });
        }

        public static ClienteGetVM ToVM(this Entities.Cliente data)
        {
            return new ClienteGetVM
            {
                Id = data.Id,
                Nome = data.Nome,
                Tels = data.Telefones.Select(t => t.Numero),
                Sexo = Enum.GetName(typeof(Core.Domain.Enums.Sexo), data.Sexo)
            };
        }
    }
}
