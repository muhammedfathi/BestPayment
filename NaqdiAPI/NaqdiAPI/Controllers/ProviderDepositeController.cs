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
            if (ProvidersDeposit.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(ProvidersDeposit.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteProvidersDeposit/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = ProvidersDeposit.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                ProvidersDeposit.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
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

    }
}
