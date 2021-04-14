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
    public class CasesCPSController : ControllerBase
    {
        private readonly BestPaymentRepo<CasesCPS> CasesCPS;

        public CasesCPSController(BestPaymentRepo<CasesCPS> _CasesCPS)
        {
            CasesCPS = _CasesCPS;
        }


        [HttpGet]
        [Route("GetAllCasesCPS")]
        public IEnumerable<CasesCPS> Get()
        {
            return CasesCPS.getAll();
        }


        [HttpGet, Route("GetCaseCPS/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (CasesCPS.Find(id) != null)
            {
                return Ok(CasesCPS.Find(id));
            }

            else { return NotFound(); }
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] CasesCPS NewCasesCPS)
        {
            if (ModelState.IsValid)
            {
                CasesCPS.add(NewCasesCPS);
                return Created("", NewCasesCPS);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] CasesCPS NewCasesCPS)
        {
            if (id != NewCasesCPS.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    CasesCPS.update(NewCasesCPS);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }


        [HttpDelete]
        [Route("DeleteCaseCPS/{id}")]
        public ActionResult Delete(int id)
        {
            if (CasesCPS.Find(id) != null)
            {
                CasesCPS.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();
        }





    }
}
