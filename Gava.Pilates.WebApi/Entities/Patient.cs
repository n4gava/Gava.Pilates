using Gava.Framework.WebApi;
using Gava.Pilates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gava.Pilates.WebApi.Entities
{
    public class Patient : BaseEntityFromVO<PatientVO>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
