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
    public class UserController : ControllerBase
    {
        private readonly BestPaymentRepo<TUser> User;

        public UserController(BestPaymentRepo<TUser> _User)
        {
            this.User = _User;
          
        }



        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<TUser> Get()
        {
            return User.getAll();
        }


        [HttpGet, Route("GetUser/{id}")]

        public ActionResult GetbyId(int id)
        {
            if (User.FindByCondition(e => e.UserId == id) != null)
            {
                return Ok(User.FindByCondition(ag => ag.UserId == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = User.FindByCondition(ag => ag.UserId == id).FirstOrDefault();
            if (entity != null)
            {
                User.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] TUser newUser)
        {
            if (ModelState.IsValid)
            {
                User.add(newUser);
                return Created("", newUser);
            }
            else
                return BadRequest();
        }



        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] TUser newUser)
        {
            if (id != newUser.UserId) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    User.update(newUser);
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
