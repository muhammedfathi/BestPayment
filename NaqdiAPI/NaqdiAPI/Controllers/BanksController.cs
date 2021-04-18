using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NaqdiBLL.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NaqdiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BestPaymentRepo<Banks> Banks;
        public BanksController(BestPaymentRepo<Banks> _Bank)
        {
            this.Banks = _Bank;
        }
        // GET: api/<TestController>
        [HttpGet]
        [Route("GetAllBanks")]
        public IEnumerable<Banks> Get()
        {
            return Banks.getAll();
        }

        // GET api/<TestController>/5
        [HttpGet, Route("GetBank/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Banks.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Banks.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Banks newEntity)
        {
            if (ModelState.IsValid)
            {
                Banks.add(newEntity);
                return Created("", newEntity);
            }
            else
                return BadRequest();
        }
        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Banks newbank)
        {
            if (id != newbank.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Banks.update(newbank);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }
     
        [HttpDelete]
        [Route("DeleteBank/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Banks.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Banks.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}