using FanSoft.CadCli.Core.Domain.Entities;
using System.Collections;
using System.Threading.Tasks;

namespace FanSoft.CadCli.Core.Domain.Contracts.Repositories
{
    public interface IClienteRepository:IRepository<Cliente>
    {
        Task<IEnumerable> GetByNomeAsync(string nome);
        IEnumerable GetByNome(string nome);
    }
}
