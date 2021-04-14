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
    public class ChargeSIMController : ControllerBase
    {
        private readonly BestPaymentRepo<ChargeSim> ChargeSim;

        public ChargeSIMController(BestPaymentRepo<ChargeSim> ChargeSim)
        {
            this.ChargeSim = ChargeSim;
        }


        [HttpGet]
        [Route("GetAllChargeSims")]
        public IEnumerable<ChargeSim> Get()
        {
            return ChargeSim.getAll();
        }


        [HttpGet, Route("GetChargeSim/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (ChargeSim.Find(id) != null)
            {
                return Ok(ChargeSim.Find(id));
            }

            else { return NotFound(); }
        }





        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] ChargeSim NewChargeSim)
        {
            if (ModelState.IsValid)
            {
                ChargeSim.add(NewChargeSim);
                return Created("", NewChargeSim);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] ChargeSim NewChargeSim)
        {
            if (id != NewChargeSim.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    ChargeSim.update(NewChargeSim);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteChargeSim/{id}")]
        public ActionResult Delete(int id)
        {
            if (ChargeSim.Find(id) != null)
            {
                ChargeSim.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();
        }
    }
}
