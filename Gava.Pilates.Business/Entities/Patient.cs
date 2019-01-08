using Gava.Framework.Entities;
using Gava.Framework.WebApi;
using Gava.Pilates.Models;
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
