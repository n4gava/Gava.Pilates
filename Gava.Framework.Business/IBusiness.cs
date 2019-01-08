using Gava.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gava.Framework.Business
{
    public interface IBusiness<TModel> where TModel : IModel
    {
        TModel FindById(long id);

        List<TModel> FindAll();

        TModel Insert(TModel patient);

        TModel Update(TModel patient);

        void Delete(long id);
    }
}
