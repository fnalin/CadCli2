using FanSoft.CadCli.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FanSoft.CadCli.Core.Data.EF
{
    public class DbInitialize
    {
        public static void Initialize(CadCliDataContext context)
        {
            context.Database.EnsureCreated();
            var dbClientes = context.Set<Cliente>();
            if (!dbClientes.Any()) {
                var clientes = new List<Cliente> {
                    new Cliente("José Carlos da Silva",Domain.Enums.Sexo.Masculino),
                    new Cliente("Maria José Pereira", Domain.Enums.Sexo.Feminino)
                };

                dbClientes.AddRange(clientes);
                context.SaveChanges();
            }
        }
    }
}
