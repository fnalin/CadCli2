using FanSoft.CadCli.Core.Domain.Contracts.Data;
using System.Threading.Tasks;

namespace FanSoft.CadCli.Core.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadCliDataContext _ctx;

        public UnitOfWork(CadCliDataContext ctx) => _ctx = ctx;

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public void RollBack()
        {
            return;
        }
    }
}
