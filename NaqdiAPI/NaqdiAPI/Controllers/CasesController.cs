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
    public class CasesController : ControllerBase

    {
        private readonly BestPaymentRepo<cases> Cases;
        public CasesController(BestPaymentRepo<cases> _Cases)
        {
            this.Cases = _Cases;
        }
        // GET: api/<CasesController>
        [HttpGet]
        [Route("GetAllCases")]
        public IEnumerable<cases> Get()
        {
            return Cases.getAll();
        }

        // GET api/<CasesController>/5
        [HttpGet("{id}")]
        [Route("GetCase/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Cases.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Cases.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteCase/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Cases.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Cases.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        // POST api/<CasesController>
        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] cases Newcases)
        {
            if (ModelState.IsValid)
            {
                Cases.add(Newcases);
                return Created("", Newcases);
            }
            else
                return BadRequest();

        }

        // PUT api/<CasesController>/5
        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] cases NewCases)
        {
            if (id != NewCases.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Cases.update(NewCases);
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
