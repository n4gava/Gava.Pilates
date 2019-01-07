using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gava.Framework.WebApi
{
    public class BaseEntityFromVO<T> : IEntityFromVO<T> where T : IModel
    {
        public long Id { get; set; }

        public virtual void LoadFromVO(T VOObject)
        {
            IDictionary<string, object> dictionary = VOObject.GetType().GetProperties(BindingFlags.Public).ToDictionary(
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(VOObject, null)
            );

            Load(dictionary);
        }

        public virtual void Load(IDictionary<string, object> data)
        {
            foreach (var item in data)
            {
                this.GetType().GetProperty(item.Key).SetValue(this, item.Value, null);
            }
        }
    }
}
