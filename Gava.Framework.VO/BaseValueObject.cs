using System;
using System.Collections.Generic;
using System.Text;

namespace Gava.Framework.VO
{
    public abstract class BaseValueObject : IValueObject
    {
        public long? Id { get; set; }
        
    }
}
