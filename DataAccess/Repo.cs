using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RapiChallenge.DataAccess
{
    public class Repo<T> : RepoBase, IRepo<T> where T : class, new()
    {
        private RapiboyContext _context;
        private RapiboyContext Context => _context ?? (_context = new RapiboyContext());
        private DbSet<T> _dbSet;
        internal DbSet<T> DbSet => _dbSet ?? (_dbSet = Context.Set<T>());
             
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            return GetList(arg => true, navigationProperties);
        }

        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return navigationProperties.Aggregate(DbSet.AsQueryable().Where(where),
                (current, property) => current.Include(property));
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void DeleteAndSaveArray(IList<T> items)
        {
            try
            {
                if (items.Any())
                {
                    DbSet.RemoveRange(items);

                    Context?.SaveChanges();
                }
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("The object cannot be deleted because it was not found in the ObjectStateManager"))
            {
                foreach (dynamic item in items)
                {
                    var newItem = DbSet.Find(item.Id);
                    Delete(newItem);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> InsertAndSaveArray(IEnumerable<T> items)
        {
            try
            {
                if (items.Any())
                {
                    DbSet.AddRange(items);

                    Context?.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return items;
        }

        public IList<T> UpdateAndSaveArray(IList<T> items)
        {
            try
            {
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        Update(item, false);
                    }

                    Context?.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return items;
        }

        public T Insert(T item)
        {
            try
            {
                item = DbSet.Add(item);

                var estado = Context.Entry(item).State;

                Context.Entry(item).State = EntityState.Added;

                Context?.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T item, bool save = true)
        {
            try
            {
                var entry = Context.Entry(item);
                if (entry.State == EntityState.Unchanged)
                {
                    return item;
                }

                if (entry.State == EntityState.Detached)
                {
                    entry = Context.Entry(DbSet.Attach(item));
                    entry.State = EntityState.Modified;
                }

                if (true)
                {
                    Context?.SaveChanges();
                }

                return item;
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("An entity object cannot be referenced by multiple instances of IEntityChangeTracker."))
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Delete(T item)
        {
            try
            {
                item = DbSet.Remove(item);

                Context?.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteById(int primaryKeyIdofThisEntity)
        {
            Delete(GetById(primaryKeyIdofThisEntity));
        }

        public IQueryable<T> DbSetContext => DbSet.AsQueryable();

        public override DbContext CurrentContext()
        {
            return Context;
        }

        public override void Dispose()
        {

            base.Dispose();

            Context?.Dispose();
        }
    }
}