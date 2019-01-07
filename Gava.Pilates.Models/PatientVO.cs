using Gava.Framework.WebApi;
using System;

namespace Gava.Pilates.Models
{
    public class PatientVO : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
