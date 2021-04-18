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
    public class PaymentCardsController : ControllerBase
    {
        private readonly BestPaymentRepo<PayMent_Cards> PaymentCards;
        public PaymentCardsController(BestPaymentRepo<PayMent_Cards> PaymentCards)
        {
            this.PaymentCards = PaymentCards;
        }


        [HttpGet]
        [Route("GetAllPaymentCards")]
        public IEnumerable<PayMent_Cards> Get()
        {
            return PaymentCards.getAll();
        }


        [HttpGet, Route("GetPaymentCard/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (PaymentCards.FindByCondition(e => e.id == id) != null)
            {
                return Ok(PaymentCards.FindByCondition(ag => ag.id == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }

        [HttpDelete]
        [Route("DeletePaymentCard/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = PaymentCards.FindByCondition(ag => ag.id == id).FirstOrDefault();
            if (entity != null)
            {
                PaymentCards.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] PayMent_Cards newPaymentCards)
        {
            if (ModelState.IsValid)
            {
                PaymentCards.add(newPaymentCards);
                return Created("", newPaymentCards);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] PayMent_Cards newPaymentCards)
        {
            if (id != newPaymentCards.id) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    PaymentCards.update(newPaymentCards);
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
