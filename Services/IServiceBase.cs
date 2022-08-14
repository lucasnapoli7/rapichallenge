using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RapiChallenge.Services
{
    public interface IServiceBase<T> : IDisposable where T : class
    {
        IQueryable<TR> Select<TR>(Expression<Func<T, TR>> selector);

        int Count(Expression<Func<T, bool>> predicate);

        T First(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);

        IQueryable<T> Where(Expression<Func<T, bool>> where);

        IQueryable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        T GetById(int Id);

        void UpdateAndSaveArray(IList<T> items);

        void DeleteAndSaveArray(IList<T> items);

        T Insert(T item);

        T Update(T item);

        void Delete(T item);

        void DeleteById(int primaryKeyIdofThisEntity);

        IQueryable<T> Repository { get; }

        T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        void InsertAndSaveArray(IList<T> items);

        bool Any(Expression<Func<T, bool>> where);
    }
}