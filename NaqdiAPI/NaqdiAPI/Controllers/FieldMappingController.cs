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
    public class FieldMappingController : ControllerBase
    {

        private readonly BestPaymentRepo<Fields_Mapping> Fields_Mapping;

        public FieldMappingController(BestPaymentRepo<Fields_Mapping> Fields_Mapping)
        {
            this.Fields_Mapping = Fields_Mapping;
        }


        [HttpGet]
        [Route("GetAllFields_Mapping")]
        public IEnumerable<Fields_Mapping> Get()
        {
            return Fields_Mapping.getAll();
        }


        [HttpGet, Route("GetFields_Mapping/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Fields_Mapping.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Fields_Mapping.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteFieldMapping/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Fields_Mapping.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Fields_Mapping.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Fields_Mapping NewFields_Mapping)
        {
            if (ModelState.IsValid)
            {
                Fields_Mapping.add(NewFields_Mapping);
                return Created("", NewFields_Mapping);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Fields_Mapping NewFields_Mapping)
        {
            if (id != NewFields_Mapping.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Fields_Mapping.update(NewFields_Mapping);
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
