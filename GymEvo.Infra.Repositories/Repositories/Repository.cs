using GymEvo.Infra.Repositories.Interfaces;
using GymEvo.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymEvo.Infra.Repositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;
        private bool _disposed = false;

        public Repository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = await _entities.AddAsync(entity);
            return result.Entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            if(entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities;
            var first = await query.FirstAsync(predicate);
            return first;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T Update(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;

            return entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposed = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Repository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
