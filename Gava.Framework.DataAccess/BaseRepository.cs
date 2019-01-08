using Gava.Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gava.Framework.DataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        private DbSet<T> _dataset;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (item?.Id == null) return default(T);

            T loadedItem = FindById(item.Id.Value);

            if (loadedItem != null)
            {
                try
                {
                    _context.Entry(loadedItem).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return loadedItem;
        }

        public bool Exists(long? id)
        {
            return _dataset.Any(b => b.Id.Equals(id));
        }
    }
}
