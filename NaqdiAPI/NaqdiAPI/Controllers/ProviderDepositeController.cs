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
    public class ProviderDepositeController : ControllerBase
    {
        private readonly BestPaymentRepo<ProvidersDeposit> ProvidersDeposit;
        public ProviderDepositeController(BestPaymentRepo<ProvidersDeposit> ProvidersDeposit)
        {
            this.ProvidersDeposit = ProvidersDeposit;
        }

        [HttpGet]
        [Route("GetAllProvidersDeposit")]
        public IEnumerable<ProvidersDeposit> Get()
        {
            return ProvidersDeposit.getAll();
        }


        [HttpGet, Route("GetProvidersDeposit/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (ProvidersDeposit.Find(id) != null)
            {
                return Ok(ProvidersDeposit.Find(id));
            }

            else { return NotFound(); }
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] ProvidersDeposit newProvidersDeposit)
        {
            if (ModelState.IsValid)
            {
                ProvidersDeposit.add(newProvidersDeposit);
                return Created("", newProvidersDeposit);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] ProvidersDeposit newProvidersDeposit)
        {
            if (id != newProvidersDeposit.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    ProvidersDeposit.update(newProvidersDeposit);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }
        // DELETE api/<TestController>/5
        [HttpDelete]
        [Route("DeleteProvidersDeposit/{id}")]
        public ActionResult Delete(int id)
        {

            if (ProvidersDeposit.Find(id) != null)
            {
                ProvidersDeposit.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }
}
