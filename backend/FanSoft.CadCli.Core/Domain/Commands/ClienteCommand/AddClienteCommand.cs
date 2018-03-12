using FanSoft.CadCli.Core.Domain.Contracts.Commands;

namespace FanSoft.CadCli.Core.Domain.Commands.ClienteCommand
{
    public class AddClienteCommand:ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
        public string[] Tels { get; set; }
    }
}
