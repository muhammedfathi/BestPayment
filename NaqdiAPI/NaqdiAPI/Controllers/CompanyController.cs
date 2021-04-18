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
            if (Company.FindByCondition(e => e.ID == id) != null)
            {
                return Ok(Company.FindByCondition(ag => ag.ID == id).FirstOrDefault());
            }

            else { return NotFound(); }
        }
        [HttpDelete]
        [Route("DeleteCompany/{id}")]
        public ActionResult Delete(int id)
        {
            var entity = Company.FindByCondition(ag => ag.ID == id).FirstOrDefault();
            if (entity != null)
            {
                Company.Delet(entity);
                return Ok();
            }
            else
                return NotFound();
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
     
    }
    }
