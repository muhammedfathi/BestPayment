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
    public class Rol_PrivFTController : ControllerBase
    {

        private readonly BestPaymentRepo<Rol_PrivFT> Rol_PrivFT;
        public Rol_PrivFTController(BestPaymentRepo<Rol_PrivFT> Rol_PrivFT)
        {
            this.Rol_PrivFT = Rol_PrivFT;
        }

        [HttpGet]
        [Route("GetAllRol_PrivFT")]
        public IEnumerable<Rol_PrivFT> Get()
        {
            return Rol_PrivFT.getAll();
        }


        [HttpGet, Route("GetRol_PrivFT/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Rol_PrivFT.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Rol_PrivFT.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteRol_PrivFT/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Rol_PrivFT.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Rol_PrivFT.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Rol_PrivFT newRol_PrivFT)
        {
            if (ModelState.IsValid)
            {
                Rol_PrivFT.add(newRol_PrivFT);
                return Created("", newRol_PrivFT);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Rol_PrivFT NewRol_PrivFT)
        {
            if (id != NewRol_PrivFT.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Rol_PrivFT.update(NewRol_PrivFT);
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

