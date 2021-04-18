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
    public class ExcuteController : ControllerBase
    {
        private readonly BestPaymentRepo<Excute> Excute;
        public ExcuteController(BestPaymentRepo<Excute> _Excute)
        {
            this.Excute = _Excute;
        }


        [HttpGet]
        [Route("GetAllExcutes")]
        public IEnumerable<Excute> Get()
        {
            return Excute.getAll();
        }


        [HttpGet, Route("GetExcute/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Excute.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Excute.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteExcute/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Excute.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Excute.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Excute newExcute)
        {
            if (ModelState.IsValid)
            {
                Excute.add(newExcute);
                return Created("", newExcute);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Excute newExcute)
        {
            if (id != newExcute.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Excute.update(newExcute);
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
