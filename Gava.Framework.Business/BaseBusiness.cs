using Gava.Framework.DataAccess;
using Gava.Framework.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gava.Framework.Business
{
    public abstract class BaseBusiness<TEntity, TModel> : IBusiness<TModel> where TModel : IModel, new() where TEntity : IEntity, new()
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

        public List<TModel> FindAll()
        {
            return _repository.FindAll().Select(e => ConvertToVO(e)).ToList();
        }

        public TModel FindById(long id)
        {
            return ConvertToVO(_repository.FindById(id));
        }

        public TModel Insert(TModel model)
        {
            TEntity patientEntity = ConvertToEntity(model);
            patientEntity = _repository.Create(patientEntity);
            return ConvertToVO(patientEntity);
        }

        public TModel Update(TModel model)
        {
            TEntity patientEntity = ConvertToEntity(model);
            patientEntity = _repository.Update(patientEntity);
            return ConvertToVO(patientEntity);
        }

        public virtual TModel ConvertToVO(TEntity entity)
        {
            if (entity == null) return default(TModel);

            IDictionary<string, object> dictionary = entity.GetType().GetProperties().ToDictionary(
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(entity, null)
            );

            return ConvertToVO(entity, dictionary);
        }

        public virtual TModel ConvertToVO(TEntity entity, IDictionary<string, object> data)
        {
            if (entity == null) return default(TModel);

            TModel model = new TModel();

            foreach (var item in data)
            {
                model.GetType().GetProperty(item.Key)?.SetValue(model, item.Value, null);
            }

            return model;
        }

        public virtual TEntity ConvertToEntity(TModel model)
        {
            if (model == null) return default(TEntity);

            IDictionary<string, object> dictionary = model.GetType().GetProperties().ToDictionary(
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(model, null)
            );

            return ConvertToEntity(model, dictionary);
        }

        public virtual TEntity ConvertToEntity(TModel model, IDictionary<string, object> data)
        {
            if (model == null) return default(TEntity);

            TEntity entity = new TEntity();

            foreach (var item in data)
            {
                entity.GetType().GetProperty(item.Key)?.SetValue(entity, item.Value, null);
            }

            return entity;
        }
    }
}
