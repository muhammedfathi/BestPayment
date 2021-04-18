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
    public class StoreController : ControllerBase
    {
        private readonly BestPaymentRepo<Store> Store;
        public StoreController(BestPaymentRepo<Store> Store)
        {
            this.Store = Store;
        }

        [HttpGet]
        [Route("GetAllStores")]
        public IEnumerable<Store> Get()
        {
            return Store.getAll();
        }


        [HttpGet, Route("GetStore/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Store.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Store.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeleteStore/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Store.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Store.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Store newStore)
        {
            if (ModelState.IsValid)
            {
                Store.add(newStore);
                return Created("", newStore);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Store newStore)
        {
            if (id != newStore.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Store.update(newStore);
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
