using Gava.Framework.Business;
using Gava.Framework.DataAccess;
using Gava.Pilates.Business.Entities;
using Gava.Pilates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gava.Pilates.Business.Business
{
    public class PatientsBusiness : BaseBusiness<Patient, PatientVO>
    {
        public PatientsBusiness(IRepository<Patient> repository) : base(repository)
        {
        }
    }
}
