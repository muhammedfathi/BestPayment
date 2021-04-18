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
    public class ReplyController : ControllerBase
    {
        private readonly BestPaymentRepo<Reply> Reply;

        public ReplyController(BestPaymentRepo<Reply> Reply)
        {
            this.Reply = Reply;
        }


        [HttpGet]
        [Route("GetAllReplys")]
        public IEnumerable<Reply> Get()
        {
            return Reply.getAll();
        }


        [HttpGet, Route("GetReply/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Reply.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Reply.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteReply/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Reply.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Reply.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }


        /// <summary>
        /// GetBY UserID &DeleteBy UserID
        /// </summary>



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Reply NewReply)
        {
            if (ModelState.IsValid)
            {
                Reply.add(NewReply);
                return Created("", NewReply);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Reply NewReply)
        {
            if (id != NewReply.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Reply.update(NewReply);
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
