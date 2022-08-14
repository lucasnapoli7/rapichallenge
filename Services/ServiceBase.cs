using RapiChallenge.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace RapiChallenge.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class, new()
    {
        public Stopwatch sw = new Stopwatch();

        private Repo<T> _repo;

        private Repo<T> _repository
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new Repo<T>();
                }

                return _repo;
            }
        }

        private DbContext _currentContext;
        public IQueryable<T> Repository => _repository.DbSetContext;
        protected DbContext CurrentContext => _currentContext ?? (_currentContext = _repository.CurrentContext());

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return _repository.DbSetContext.Where(where);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            return _repository.GetAll(navigationProperties);
        }

        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return _repository.GetList(where, navigationProperties);
        }

        public virtual void UpdateAndSaveArray(IList<T> items)
        {
            if (items == null)
            {
                throw new ArgumentException("The argument item can not be null");
            }

            _repository.UpdateAndSaveArray(items);
        }

        public virtual void DeleteAndSaveArray(IList<T> items)
        {
            if (items == null)
            {
                throw new ArgumentException("The argument item can not be null");
            }

            _repository.DeleteAndSaveArray(items);
        }

        public virtual T Insert(T item)
        {
            if (item == default(T))
            {
                throw new ArgumentException("The argument item can not be null");
            }

            return _repository.Insert(item);
        }

        public virtual T Update(T item)
        {
            if (item == default(T))
            {
                throw new ArgumentException("The argument item can not be null");
            }

            return _repository.Update(item);
        }

        public virtual void Delete(T item)
        {
            if (item == default(T))
            {
                throw new ArgumentException("The argument item can not be null");
            }

            _repository.Delete(item);
        }

        public virtual void DeleteById(int primaryKeyIdofThisEntity)
        {
            _repository.DeleteById(primaryKeyIdofThisEntity);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return _repository.GetList(where, navigationProperties).FirstOrDefault();
        }

        public virtual void InsertAndSaveArray(IList<T> items)
        {
            _repository.InsertAndSaveArray(items);
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return _repository.DbSetContext.Any(where);
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
        {
            return _repository.DbSetContext.Select(selector);
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return _repository.DbSetContext.Count(where);
        }

        public T First(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return _repository.GetList(where, navigationProperties).First();
        }

        public virtual void Dispose()
        {
            _repository?.Dispose();
        }
    }
}