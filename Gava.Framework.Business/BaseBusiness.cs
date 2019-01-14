using Gava.Framework.DataAccess;
using Gava.Framework.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gava.Framework.Business
{
    public abstract class BaseBusiness<TEntity> : IBusiness<TEntity> where TEntity : IEntity, new()
    {
        private IRepository<TEntity> _repository;

        public BaseBusiness(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<TEntity> FindAll()
        {
            return _repository.FindAll();
        }

        public TEntity FindById(long id)
        {
            return _repository.FindById(id);
        }

        public TEntity Insert(TEntity entity)
        {
            entity = _repository.Create(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            entity = _repository.Update(entity);
            return entity;
        }
    }
}
