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
    public class AgentCommissionController : ControllerBase
    {
        private readonly BestPaymentRepo<AgentCommissions> AgentCommissions;

        public AgentCommissionController(BestPaymentRepo<AgentCommissions> _AgentCommissions)
        {
            AgentCommissions = _AgentCommissions;
        }


        [HttpGet]
        [Route("GetAllAgentCommissions")]
        public IEnumerable<AgentCommissions> Get()
        {
            return AgentCommissions.getAll();
        }


        [HttpGet, Route("GetAgentCommission/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (AgentCommissions.FindByCondition(e=>e.ID==id)!=null)
            {
                return Ok(AgentCommissions.FindByCondition(ag=>ag.ID==id).FirstOrDefault());
            }

            else { return NotFound(); }
        }




        [HttpGet, Route("GetAgentCommission/{id}")]
        public ActionResult GetbyUserId(int userID)
        {
            if (AgentCommissions.FindByCondition(e => e.UserID == userID) != null)
            {
                return Ok(AgentCommissions.FindByCondition(ag => ag.ID == userID));
            }

            else { return NotFound(); }
        }




        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] AgentCommissions NewAgentCommissions)
        {
            if (ModelState.IsValid)
            {
                AgentCommissions.add(NewAgentCommissions);
                return Created("", NewAgentCommissions);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] AgentCommissions NewAgentCommissions)
        {
            if (id != NewAgentCommissions.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    AgentCommissions.update(NewAgentCommissions);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }


        [HttpDelete]
        [Route("DeleteAgentCommission/{id}")]
        public ActionResult Delete(int id)
        {
          var entity=  AgentCommissions.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                AgentCommissions.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("DeleteAgentCommByUID/{UID}")]
        public ActionResult DeleteByUID(int UID)
        {
            var entity = AgentCommissions.FindByCondition(ag => ag.UserID == UID).FirstOrDefault();
            if (entity != null)
            {
                AgentCommissions.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

    }
}
