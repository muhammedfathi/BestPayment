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
            if (Store.Find(id) != null)
            {
                return Ok(Store.Find(id));
            }

            else { return NotFound(); }
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


        [HttpDelete]
        [Route("DeleteStore/{id}")]
        public ActionResult Delete(int id)
        {

            if (Store.Find(id) != null)
            {
                Store.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }
}
