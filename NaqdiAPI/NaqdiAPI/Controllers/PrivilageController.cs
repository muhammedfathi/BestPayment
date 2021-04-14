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
    public class PrivilageController : ControllerBase
    {
        private readonly BestPaymentRepo<privilage> privilage;
        public PrivilageController(BestPaymentRepo<privilage> privilage)
        {
            this.privilage = privilage;
        }

        [HttpGet]
        [Route("GetAllprivilages")]
        public IEnumerable<privilage> Get()
        {
            return privilage.getAll();
        }


        [HttpGet, Route("Getprivilage/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (privilage.Find(id) != null)
            {
                return Ok(privilage.Find(id));
            }

            else { return NotFound(); }
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] privilage newprivilage)
        {
            if (ModelState.IsValid)
            {
                privilage.add(newprivilage);
                return Created("", newprivilage);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] privilage newprivilage)
        {
            if (id != newprivilage.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    privilage.update(newprivilage);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("Deleteprivilage/{id}")]
        public ActionResult Delete(int id)
        {

            if (privilage.Find(id) != null)
            {
                privilage.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }
}
