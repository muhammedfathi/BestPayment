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
    public class Service_ProviderController : ControllerBase
    {
        private readonly BestPaymentRepo<Service_Provider> Service_Provider;
        public Service_ProviderController(BestPaymentRepo<Service_Provider> Service_Provider)
        {
            this.Service_Provider = Service_Provider;
        }
        [HttpGet]
        [Route("GetAllService_Providers")]
        public IEnumerable<Service_Provider> Get()
        {
            return Service_Provider.getAll();
        }

        [HttpGet, Route("GetService_Provider/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Service_Provider.FindByCondition(e => e.Serv_ProvID == id) != null)
            {
                return Ok(Service_Provider.FindByCondition(ag => ag.Serv_ProvID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteService_Provider/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Service_Provider.FindByCondition(ag => ag.Serv_ProvID == id).FirstOrDefault();
            if (entity != null)
            {
                Service_Provider.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Service_Provider newService_Provider)
        {
            if (ModelState.IsValid)
            {
                Service_Provider.add(newService_Provider);
                return Created("", newService_Provider);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Service_Provider newService_Provider)
        {
            if (id != newService_Provider.Serv_ProvID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Service_Provider.update(newService_Provider);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }
    }
}