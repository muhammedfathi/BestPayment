using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NaqdiBLL.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace NaqdiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  

        public class ProvidersController : ControllerBase
    {
            private readonly BestPaymentRepo<Provider> Provider;
        public ProvidersController(BestPaymentRepo<Provider> _Provider)
        {
            this.Provider = _Provider;
        }

            // GET: api/<ProvidersController>
         [HttpGet]
        [Route("GetAllProviders")]
        public IEnumerable<Provider> Get()
        {
            return Provider.getAll();
        }

        // GET api/<ProvidersController>/5
        [HttpGet]
        [Route("GetProvider/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Provider.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Provider.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteProvider/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Provider.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Provider.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        // POST api/<ProvidersController>
        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Provider NewProvider)
        {
            if (ModelState.IsValid)
            {
                Provider.add(NewProvider);
                return Created("",NewProvider);
            }
            return BadRequest();
        }

        // PUT api/<ProvidersController>/5
        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Provider NewProvider)
        {
            if (id!=NewProvider.ID)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try { 
                Provider.update(NewProvider);
                return Ok(NewProvider);
                }
                catch(Exception ex)
                {
                    return NotFound();
                }

            }
            return BadRequest();

        }

    }
}
