using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gava.Framework.WebApi;
using Gava.Pilates.Business.Business;
using Gava.Pilates.Business.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gava.Pilates.WebApi.Controllers
{
    public class PatientController : BaseEntityController<Patient>
    {
        public PatientController(DbContext dbContext, PatientsBusiness patientsBusiness) : base(dbContext, patientsBusiness)
        {

        }
    }
}
