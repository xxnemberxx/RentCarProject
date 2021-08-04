using Core.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IDto, new()
        where TContext : DbContext, new() 
    {
        public void Add(TEntity entity)
        {
            // Garbage Collecter, using bitince çalışır
            // IDisposable pattern implementation of c# 
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // referansını getir
                addedEntity.State = EntityState.Added; // ekleme işlemi olacak
                context.SaveChanges(); // İşlemleri gerçekleştir
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // referansını getir
                deletedEntity.State = EntityState.Deleted; // Silme işlemi olacak
                context.SaveChanges(); // İşlemleri gerçekleştir
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return (filter == null)
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // referansını getir
                updatedEntity.State = EntityState.Modified; // Güncelleme işlemi olacak
                context.SaveChanges(); // İşlemleri gerçekleştir
            }
        }
    }
}
