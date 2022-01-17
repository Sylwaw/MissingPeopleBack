using System;
using System.Linq;
using MissingPeople.Core.Interfaces.Repository;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MissingPeople.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MissingPeople.Infrastructure.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly MissingPeopleDbContext context;

        public RepositoryBase(MissingPeopleDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await this.context.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.context.Remove(entity);
            await this.context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.context.Set<T>().FirstOrDefaultAsync(s => s.Id == id);
        }

        public IQueryable<T> GetByFunc(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            this.context.Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}