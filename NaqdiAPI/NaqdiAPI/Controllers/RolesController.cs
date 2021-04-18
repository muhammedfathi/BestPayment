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
    public class RolesController : ControllerBase
    {
        private readonly BestPaymentRepo<Role> role;
        public RolesController(BestPaymentRepo<Banks> _Bank, BestPaymentRepo<Company> _company, BestPaymentRepo<Role> _Role)
        {
            role = _Role;
        }
        // GET: api/<TestController>
        [HttpGet]
        [Route("GetAllRoles")]
        public IEnumerable<Role> Get()
        {
            return role.getAll();
        }

        // GET api/<TestController>/5
        [HttpGet, Route("GetRole/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (role.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(role.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = role.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                role.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Role newEntity)
        {
            if (ModelState.IsValid)
            {
                role.add(newEntity);
                return Created("", newEntity);
            }
            else
                return BadRequest();
        }
        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Role newRole)
        {
            if (id != newRole.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    role.update(newRole);
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