using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gava.Framework.WebApi;
using Gava.Pilates.Business.Business;
using Gava.Pilates.Business.Entities;
using Gava.Pilates.WebApi.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gava.Pilates.WebApi.Controllers
{
    public class PatientController : ODataController
    {
        AppDbContext _dbContext;

        public PatientController(AppDbContext dbContext, PatientsBusiness patientsBusiness)
        {
            _dbContext = dbContext;
        }

        [EnableQuery]
        public IQueryable<Patient> Get()
        {
            return _dbContext.Patients;
        }

        [EnableQuery]
        public SingleResult Get(int id)
        {
            var result = _dbContext.Patients.Where(p => p.Id == id);
            return SingleResult.Create(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Patient patient)
        {
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();
            return Ok(patient);
        }



    }
}
