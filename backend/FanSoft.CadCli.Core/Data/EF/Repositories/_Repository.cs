using FanSoft.CadCli.Core.Domain.Contracts.Repositories;
using FanSoft.CadCli.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FanSoft.CadCli.Core.Data.EF.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly CadCliDataContext _ctx;
        public Repository(CadCliDataContext ctx) => _ctx = ctx;


        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Del(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public void Del(IEnumerable<T> entities)
        {
            _ctx.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>().AsNoTracking();
        }

        public T Get(object key)
        {
            return _ctx.Set<T>().Find(key);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _ctx.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(object key)
        {
            return await _ctx.Set<T>().FindAsync(key);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

       
    }
}
