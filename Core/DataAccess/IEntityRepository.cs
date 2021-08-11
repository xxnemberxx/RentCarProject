using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    // Generic Constraint - where
    // class : referance type
    // IEntity -> IEntity olabilir ya da implemente eden bir nesne olabilir
    // new() : Oluşturulan, yer tutan bir nesne olabilir 
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entityId);
        void Delete(T entity);
    }
}
