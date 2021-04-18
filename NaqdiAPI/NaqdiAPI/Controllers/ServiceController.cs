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
        public ActionResult GetbyId(int id)
        {
            if (service.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(service.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteService/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = service.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                service.Delet(entity);
                return Ok();
            }
            else
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

    }
}
