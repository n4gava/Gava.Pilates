using System;
using System.Collections.Generic;
using System.Text;

namespace Gava.Framework.WebApi
{
    public interface IEntityFromVO<T> : IEntity where T : IModel
    {
        void LoadFromVO(T VOObject);

        void Load(IDictionary<string, object> data);
    }
}
