using FanSoft.CadCli.Core.Domain.Contracts.Commands;
using FanSoft.CadCli.Core.Domain.Contracts.Repositories;
using FanSoft.CadCli.Core.Domain.Entities;
using FanSoft.CadCli.Core.Domain.Enums;

namespace FanSoft.CadCli.Core.Domain.Commands.ClienteCommand
{
    public class ClientesCommandHandler : CommandHandler, ICommandHandler<AddClienteCommand>
    {
        private readonly IClienteRepository _cliRepo;

        public ClientesCommandHandler(IClienteRepository cliRepo) => _cliRepo = cliRepo;

        public object Handle(AddClienteCommand command)
        {
            

            if (command == null)
            {
                Errors.Add(new FluentValidation.Results.ValidationFailure("", "Objeto inválido"));
                return null;
            }

            var cliente = new Cliente(command.Nome, (Sexo)command.Sexo);
            var clienteValidator = new ClienteValidator();
            var result = clienteValidator.Validate(cliente);

            if (result.IsValid)
            {
                _cliRepo.Add(cliente);
                return cliente;
            }


            Errors = result.Errors;
            return null;

        }
    }
}
