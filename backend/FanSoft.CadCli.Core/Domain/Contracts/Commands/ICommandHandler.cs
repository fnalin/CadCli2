namespace FanSoft.CadCli.Core.Domain.Contracts.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
        object Handle(T command);
    }
}
