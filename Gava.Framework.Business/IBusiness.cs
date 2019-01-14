using Gava.Framework.Entities;
using System.Collections.Generic;

namespace Gava.Framework.Business
{
    public interface IBusiness<TEntity> where TEntity : IEntity
    {
        TEntity FindById(long id);

        List<TEntity> FindAll();

        TEntity Insert(TEntity patient);

        TEntity Update(TEntity patient);

        void Delete(long id);
    }
}
