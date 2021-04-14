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
    public class CompanyController : ControllerBase
    {
        private readonly BestPaymentRepo<Company> Company;
        public CompanyController(BestPaymentRepo<Company> _company)
        {
            this.Company = _company;
        }
      

        [HttpGet]
        [Route("GetAllCompanies")]
        public IEnumerable<Company> Get()
        {
            return Company.getAll();
        }

   
        [HttpGet, Route("GetCompany/{id}")]
        public ActionResult GetbyId(int id)
        {
            if (Company.Find(id) != null)
            {
                return Ok(Company.Find(id));
            }

            else { return NotFound(); }
        }



        [HttpPost]
        [Route("AddNew")]
        public ActionResult Post([FromBody] Company newCompany)
        {
            if (ModelState.IsValid)
            {
                Company.add(newCompany);
                return Created("", newCompany);
            }
            else
                return BadRequest();
        }


        [HttpPut]
        [Route("UpdateNew/{id}")]
        public ActionResult Put(int id, [FromBody] Company newCompany)
        {
            if (id != newCompany.ID) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                try
                {
                    Company.update(newCompany);
                    return Ok();
                }
                catch
                { return NotFound(); }
            }
            else
                return BadRequest();
        }
        // DELETE api/<TestController>/5
        [HttpDelete]
        [Route("DeleteCompany/{id}")]
        public ActionResult Delete(int id)
        {

            if (Company.Find(id) != null)
            {
                Company.Delet(id);
                return Ok();
            }
            else //NOtFOund 
                return NotFound();

        }
    }
    }
