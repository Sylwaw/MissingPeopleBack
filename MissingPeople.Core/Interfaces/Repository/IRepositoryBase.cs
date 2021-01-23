using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MissingPeople.Core.Entities;

namespace MissingPeople.Core.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetByFunc(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T entity);
    }
}