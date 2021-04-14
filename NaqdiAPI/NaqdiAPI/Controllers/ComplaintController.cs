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
    public class ComplaintController : ControllerBase
    {
        private readonly BestPaymentRepo<Complaint> Complaint;

        public ComplaintController(BestPaymentRepo<Complaint> Complaint)
        {
            this.Complaint = Complaint;
        }


        [HttpGet]
        [Route("GetAllComplaints")]
        public IEnumerable<Complaint> Get()
        {
            return Complaint.getAll();
        }


        [HttpGet, Route("GetComplaint/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Complaint.Find(id) != null)
            {
                return Ok(Complaint.Find(id));
            }

            else { return NotFound(); }
        }


        /// <summary>
        /// GetBY UserID &DeleteBy UserID
        /// </summary>



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Complaint NewComplaint)
        {
            if (ModelState.IsValid)
            {
                Complaint.add(NewComplaint);
                return Created("", NewComplaint);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Complaint NewComplaint)
        {
            if (id != NewComplaint.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Complaint.update(NewComplaint);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteComplaint/{id}")]
        public ActionResult Delete(int id)
        {
            if (Complaint.Find(id) != null)
            {
                Complaint.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();
        }
    }
}
