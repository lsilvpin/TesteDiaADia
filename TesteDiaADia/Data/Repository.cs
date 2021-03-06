using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using TesteDiaADia.Interfaces;

namespace TesteDiaADia.Data
{
    internal class Repository<T>
        where T : class, IIdentifiable
    {
        private readonly ILogger<Repository<T>> logger;
        private readonly EfContext db;
        private readonly DbSet<T> set;

        protected Repository(EfContext db,
            ILogger<Repository<T>> logger)
        {
            this.logger = logger;
            this.db = db;
            set = db.Set<T>();
        }

        public int Create(T entity)
        {
            set.Add(entity);
            return entity.Id;
        }

        public List<int> Create(List<T> entities)
        {
            List<int> ids = new List<int>();
            entities.ForEach(e => ids.Add(Create(e)));
            return ids;
        }

        public T FirstOrDefault(Func<T, bool> lambda)
        {
            return set.FirstOrDefault(lambda);
        }

        public T SingleOrDefault(Func<T, bool> lambda)
        {
            return set.SingleOrDefault(lambda);
        }

        public bool Any(Func<T, bool> predicate)
        {
            return set.Any(predicate);
        }

        public IQueryable<T> All()
        {
            return set.AsQueryable();
        }

        public IQueryable<T> Where(Func<T, bool> lambda)
        {
            return set.Where(lambda).AsQueryable();
        }

        public IQueryable<OUT> Select<OUT>(Func<T, OUT> lambda)
        {
            return set.Select(lambda).AsQueryable();
        }

        public IQueryable<T> OrderBy<OUT>(Func<T, OUT> lambda)
        {
            return set.OrderBy(lambda).AsQueryable();
        }

        public void Update(T entity)
        {
            set.Update(entity);
        }

        public void Update(List<T> entities)
        {
            entities.ForEach(e => Update(e));
        }

        public void Delete(int entityId)
        {
            T entity = set.Find(entityId);
            set.Remove(entity);
        }

        public void Delete(List<int> entitiesIds)
        {
            entitiesIds.ForEach(id => Delete(id));
        }

        public void Commit()
        {
            using IDbContextTransaction trans = db.Database.BeginTransaction();
            try
            {
                db.SaveChanges();
                trans.Commit();
            }
            catch (DbException dbEx)
            {
                logger.LogError(dbEx.Message);
                throw;
            }
            catch (DbUpdateException updateEx)
            {
                logger.LogError(updateEx.Message);
                throw;
            }
        }
    }
}
