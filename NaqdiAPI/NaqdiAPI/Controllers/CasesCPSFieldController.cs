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
    public class CasesCPSFieldController : ControllerBase
    {
        private readonly BestPaymentRepo<CasesCPSField_Prov> CasesCPSField_Prov;

        public CasesCPSFieldController(BestPaymentRepo<CasesCPSField_Prov> _CasesCPSField_Prov)
        {
            CasesCPSField_Prov = _CasesCPSField_Prov;
        }


        [HttpGet]
        [Route("GetAllCasesCPSField")]
        public IEnumerable<CasesCPSField_Prov> Get()
        {
            return CasesCPSField_Prov.getAll();
        }


        [HttpGet, Route("GetCasesCPSField/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (CasesCPSField_Prov.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(CasesCPSField_Prov.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpGet, Route("CaseCPSFieldByCID/{id}")]
        public ActionResult GetbyCaseCPSID(int CID)
        {
            if (CasesCPSField_Prov.FindByCondition(e => e.CasesCPS_ID == CID) != null)
            {
                return Ok(CasesCPSField_Prov.FindByCondition(ag => ag.CasesCPS_ID == CID).FirstOrDefault());
            }

            else { return NotFound(); }
        }


        [HttpDelete]
        [Route("DeleteCasesCPSField/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = CasesCPSField_Prov.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                CasesCPSField_Prov.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }


        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] CasesCPSField_Prov NewCasesCPSField_Prov)
        {
            if (ModelState.IsValid)
            {
                CasesCPSField_Prov.add(NewCasesCPSField_Prov);
                return Created("", NewCasesCPSField_Prov);
            }
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] CasesCPSField_Prov NewCasesCPSField_Prov)
        {
            if (id != NewCasesCPSField_Prov.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    CasesCPSField_Prov.update(NewCasesCPSField_Prov);
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