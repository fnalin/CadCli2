using FanSoft.CadCli.Core.Domain.Entities;
using FluentValidation;

namespace FanSoft.CadCli.Core.Domain.Commands.ClienteCommand
{
    public class ClienteValidator:AbstractValidator<Cliente>
    {

        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome).NotEmpty().WithMessage("Informe um nome válido");
            RuleFor(cliente => cliente.Nome).Length(3, 100).WithMessage("Informe um nome válido de 3 à 100 caracteres");
        }
    }
}
