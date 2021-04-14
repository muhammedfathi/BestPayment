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
    public class ServiceController : ControllerBase
    {
        private readonly BestPaymentRepo<Service> service;

        public ServiceController(BestPaymentRepo<Service> _service)
        {
            this.service = _service;
        }

        [HttpGet]
        [Route("GetAllService")]
        public IEnumerable<Service> Get()
        {
            return service.getAll();
        }

        // GET api/<ServiceController>/5
        [HttpGet]
        [Route("GetService/{id}")]
        public ActionResult Get(int id)
        {
            if (service.Find(id) != null)
            {
                return Ok(service.Find(id));
            }
                return NotFound();
        }

        // POST api/<ServiceController>
        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Service NewService)
        {
            if (ModelState.IsValid)
            {
                service.add(NewService);
                return Created("", NewService);
            }
            else
                return BadRequest();
        }
        // PUT api/<ServiceController>/5
        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Service NewService)
        {
            if (id != NewService.ID) { return BadRequest(); }
            
            if (ModelState.IsValid)
            {
                try
                {
                    service.update(NewService);
                    return Ok();
                }
                catch (Exception Ex)
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete]
        [Route("DeleteService/{id}")]
        public ActionResult Delete(int id)
        {

            if (service.Find(id) != null)
            {
                service.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();
            
        }
    }
}
