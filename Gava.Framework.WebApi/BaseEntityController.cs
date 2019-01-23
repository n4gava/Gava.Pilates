using Gava.Framework.Business;
using Gava.Framework.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gava.Framework.WebApi
{
    public class BaseEntityController<TEntity> : ODataController where TEntity: IEntity
    {
        private DbContext _dbContext;
        private IBusiness<TEntity> _business;

        public BaseEntityController(DbContext dbContext, IBusiness<TEntity> business)
        {
            _dbContext = dbContext;
            _business = business;
        }

        // GET api/values
        [HttpGet]
        [EnableQuery]
        public ActionResult Get()
        {
            return Ok(_business.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [EnableQuery]
        public ActionResult Get(long id)
        {
            return Ok(_business.FindById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] TEntity entity)
        {
            if (entity == null) return BadRequest();
            return Ok(_business.Insert(entity));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] TEntity entity)
        {
            if (entity == null) return BadRequest();
            return Ok(_business.Update(entity));
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
