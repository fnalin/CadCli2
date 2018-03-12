using System.Threading.Tasks;

namespace FanSoft.CadCli.Core.Domain.Contracts.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void RollBack();
    }
}
