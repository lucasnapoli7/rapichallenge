using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RapiChallenge.DataAccess
{
    public interface IRepo<T> where T : class
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        IQueryable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        T GetById(int id);

        IList<T> UpdateAndSaveArray(IList<T> items);

        void DeleteAndSaveArray(IList<T> items);

        IEnumerable<T> InsertAndSaveArray(IEnumerable<T> items);

        T Insert(T item);

        T Update(T item, bool save = true);

        T Delete(T item);

        IQueryable<T> DbSetContext { get; }
    }
}