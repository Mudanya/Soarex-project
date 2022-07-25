using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _context;
        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public void Create(T entity)=> _context.Add(entity);

        public void Delete(T entity)=> _context.Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(
            Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ? _context.Set<T>().Where(expression) 
            : _context.Set<T>().Where(expression).AsNoTracking();

        public void Update(T entity)=>_context.Update(entity);
        public IQueryable<T> Find(bool trackChanges) =>
            trackChanges? _context.Set<T>() : _context.Set<T>().AsNoTracking();
    }
}