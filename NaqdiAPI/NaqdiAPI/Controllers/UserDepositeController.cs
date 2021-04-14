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
    public class UserDepositeController : ControllerBase
    {
        private readonly BestPaymentRepo<UsersDeposit> UsersDeposit;

        public UserDepositeController(BestPaymentRepo<UsersDeposit> UsersDeposit)
        {
            this.UsersDeposit = UsersDeposit;

        }


        [HttpGet]
        [Route("GetAllUserDeposits")]
        public IEnumerable<UsersDeposit> Get()
        {
            return UsersDeposit.getAll();
        }


        [HttpGet, Route("GetUserDeposit/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (UsersDeposit.Find(id) != null)
            {
                return Ok(UsersDeposit.Find(id));
            }

            else { return NotFound(); }
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] UsersDeposit newUsersDeposit)
        {
            if (ModelState.IsValid)
            {
                UsersDeposit.add(newUsersDeposit);
                return Created("", newUsersDeposit);
            }
            else
                return BadRequest();
        }



        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] UsersDeposit NewUsersDeposit)
        {
            if (id != NewUsersDeposit.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    UsersDeposit.update(NewUsersDeposit);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }



        [HttpDelete]
        [Route("DeleteUsersDeposit/{id}")]
        public ActionResult Delete(int id)
        {

            if (UsersDeposit.Find(id) != null)
            {
                UsersDeposit.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }


}
