using HomeFixService.WebService.Models;
using System;
using System.Collections.Generic;

namespace HomeFixService.WebService.Persistence
{
    interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        T FindById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}
