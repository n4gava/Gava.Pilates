using Gava.Framework.Entities;
using System;

namespace Gava.Pilates.Business.Entities
{
    public class Patient : BaseEntity
    {
        public Patient() { }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
