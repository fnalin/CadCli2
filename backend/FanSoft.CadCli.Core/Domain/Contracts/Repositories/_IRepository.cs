using FanSoft.CadCli.Core.Domain.Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FanSoft.CadCli.Core.Domain.Contracts.Repositories
{
    public interface IRepository<T> :
       IDisposable where T : IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Del(T entity);
        void Del(IEnumerable<T> entities);

        IEnumerable<T> Get();
        Task<IEnumerable<T>> GetAsync();
        T Get(object key);
        Task<T> GetAsync(object key);
    }
}
