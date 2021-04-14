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
    public class ChargeOperationController : ControllerBase
    {
        private readonly BestPaymentRepo<ChargeOperation> charge_Operation;

        public ChargeOperationController(BestPaymentRepo<ChargeOperation> _charg_operation)
        {
            charge_Operation = _charg_operation;
        }


        [HttpGet]
        [Route("GetAllchargeOperations")]
        public IEnumerable<ChargeOperation> Get()
        {
            return charge_Operation.getAll();
        }


        [HttpGet, Route("GetchargeOperation/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (charge_Operation.Find(id) != null)
            {
                return Ok(charge_Operation.Find(id));
            }

            else { return NotFound(); }
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] ChargeOperation NewChargeOperation)
        {
            if (ModelState.IsValid)
            {
                charge_Operation.add(NewChargeOperation);
                return Created("", NewChargeOperation);
            }
            else
                return BadRequest();
        }



        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] ChargeOperation NewChargeOperation)
        {
            if (id != NewChargeOperation.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    charge_Operation.update(NewChargeOperation);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }



        [HttpDelete]
        [Route("DeleteChargeOperation/{id}")]
        public ActionResult Delete(int id)
        {

            if (charge_Operation.Find(id) != null)
            {
                charge_Operation.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }
}
