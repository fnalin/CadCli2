using FluentValidation.Results;
using System.Collections.Generic;

namespace FanSoft.CadCli.Core.Domain.Commands
{
    public abstract class CommandHandler
    {
        public IList<ValidationFailure> Errors { get; set; }
    }
}
