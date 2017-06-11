using HomeFixService.WebService.Models;
using HomeFixService.WebService.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class CrudRepository<T> : BaseRepository, IRepository<T> where T : BaseEntity
    {

        DbSet<T> DbSet;

        public CrudRepository() : base()
        {
            DbSet = this.DatabaseContext.Set<T>();
        }

        public CrudRepository(DatabaseContext context) : base(context)
        {
            DbSet = context.Set<T>();
        }

        public void Add(T item)
        {
            this.DbSet.Add(item);
            this.DatabaseContext.SaveChanges();
        }

        public T FindById(int id)
        {
            return this.DbSet.Find(id);
        }

        public IEnumerable<T> Get()
        {
            return this.DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return this.DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(T item)
        {
            this.DbSet.Attach(item);
            this.DbSet.Remove(item);
            this.DatabaseContext.SaveChanges();
        }

        public void Update(T item)
        {
            this.DatabaseContext.Entry(item).State = EntityState.Modified;
            this.DatabaseContext.SaveChanges();
        }
    }
}