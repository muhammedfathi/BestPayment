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
            if (AgentCommissions.Find(id) != null)
            {
                return Ok(AgentCommissions.Find(id));
            }

            else { return NotFound(); }
        }


        /// <summary>
        /// GetBY UserID &DeleteBy UserID
        /// </summary>
     

        
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
            if (AgentCommissions.Find(id) != null)
            {
                AgentCommissions.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();
        }
    }
}
