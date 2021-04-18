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
    public class ExcuteResponseController : ControllerBase
    {
        private readonly BestPaymentRepo<Execution_Response> Execution_Response;
        public ExcuteResponseController(BestPaymentRepo<Execution_Response> Execution_Response)
        {
            this.Execution_Response = Execution_Response;
        }


        [HttpGet]
        [Route("GetAllExecution_Responses")]
        public IEnumerable<Execution_Response> Get()
        {
            return Execution_Response.getAll();
        }

        [HttpGet, Route("GetExecution_Response/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Execution_Response.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Execution_Response.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }
            
            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteExecution_Response/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Execution_Response.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Execution_Response.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Execution_Response newExecution_Response)
        {
            if (ModelState.IsValid)
            {
                Execution_Response.add(newExecution_Response);
                return Created("", newExecution_Response);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Execution_Response newExecution_Response)
        {
            if (id != newExecution_Response.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Execution_Response.update(newExecution_Response);
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

