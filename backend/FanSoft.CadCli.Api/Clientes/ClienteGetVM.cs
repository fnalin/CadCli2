using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanSoft.CadCli.Api.Clientes
{
    public class ClienteGetVM
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Sexo { get; set; }

        public IEnumerable<string> Tels { get; set; } = new List<string>();

    }
    
}
