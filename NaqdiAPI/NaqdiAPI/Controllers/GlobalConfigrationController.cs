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
    public class GlobalConfigrationController : ControllerBase
    {
        private readonly BestPaymentRepo<GlobalConfigration> GlobalConfigration;
        public GlobalConfigrationController(BestPaymentRepo<GlobalConfigration> GlobalConfigration)
        {
            this.GlobalConfigration = GlobalConfigration;
        }


        [HttpGet]
        [Route("GetAllGlobalConfigration")]
        public IEnumerable<GlobalConfigration> Get()
        {
            return GlobalConfigration.getAll();
        }


        [HttpGet, Route("GetGlobalConfigration/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (GlobalConfigration.Find(id) != null)
            {
                return Ok(GlobalConfigration.Find(id));
            }

            else { return NotFound(); }
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] GlobalConfigration newGlobalConfigration)
        {
            if (ModelState.IsValid)
            {
                GlobalConfigration.add(newGlobalConfigration);
                return Created("", newGlobalConfigration);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] GlobalConfigration newGlobalConfigration)
        {
            if (id != newGlobalConfigration.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    GlobalConfigration.update(newGlobalConfigration);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }
        
        [HttpDelete]
        [Route("DeleteGlobalConfigration/{id}")]
        public ActionResult Delete(int id)
        {

            if (GlobalConfigration.Find(id) != null)
            {
                GlobalConfigration.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }
}
