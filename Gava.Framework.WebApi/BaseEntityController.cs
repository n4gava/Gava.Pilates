using Gava.Framework.Business;
using Gava.Framework.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gava.Framework.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity, TVO> : ControllerBase where TVO: IModel where TEntity: IEntity
    {
        private DbContext _dbContext;
        private IBusiness<TVO> _business;

        public BaseEntityController(DbContext dbContext, IBusiness<TVO> business)
        {
            _dbContext = dbContext;
            _business = business;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_business.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            return Ok(_business.FindById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] TVO model)
        {
            if (model == null) return BadRequest();
            return Ok(_business.Insert(model));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] TVO model)
        {
            if (model == null) return BadRequest();
            return Ok(_business.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _business.Delete(id);
            return NoContent();
        }
    }
}
