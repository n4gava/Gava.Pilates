using Gava.Framework.Entities;
using System;
using System.Collections.Generic;

namespace Gava.Framework.DataAccess
{
    public interface IRepository<T> where T : IEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
    }
}
