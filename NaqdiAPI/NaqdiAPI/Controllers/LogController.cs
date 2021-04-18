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
    public class LogController : ControllerBase
    {
        private readonly BestPaymentRepo<Log> Log;
        public LogController(BestPaymentRepo<Log> Log)
        {
            this.Log = Log;
        }


        [HttpGet]
        [Route("GetAllLogs")]
        public IEnumerable<Log> Get()
        {
            return Log.getAll();
        }


        [HttpGet, Route("GetLog/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Log.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Log.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteLog/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Log.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Log.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Log newLog)
        {
            if (ModelState.IsValid)
            {
                Log.add(newLog);
                return Created("", newLog);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Log newLog)
        {
            if (id != newLog.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Log.update(newLog);
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

