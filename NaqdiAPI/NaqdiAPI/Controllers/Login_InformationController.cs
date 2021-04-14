
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
    public class Login_InformationController : ControllerBase
    {
        private readonly BestPaymentRepo<Login_Information> Login_Information;
        public Login_InformationController(BestPaymentRepo<Login_Information> Login_Information)
        {
            this.Login_Information = Login_Information;
        }


        [HttpGet]
        [Route("GetAllLogin_Information")]
        public IEnumerable<Login_Information> Get()
        {
            return Login_Information.getAll();
        }


        /// <summary>
        /// UserID NOt RowID??
        /// </summary>
      

        [HttpGet, Route("GetLogin_Information/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Login_Information.Find(id) != null)
            {
                return Ok(Login_Information.Find(id));
            }

            else { return NotFound(); }
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Login_Information newLogin_Information)
        {
            if (ModelState.IsValid)
            {
                Login_Information.add(newLogin_Information);
                return Created("", newLogin_Information);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Login_Information newLogin_Information)
        {
            if (id != newLogin_Information.id) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Login_Information.update(newLogin_Information);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }


        [HttpDelete]
        [Route("DeleteLogin_Information/{id}")]
        public ActionResult Delete(int id)
        {

            if (Login_Information.Find(id) != null)
            {
                Login_Information.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }
}


