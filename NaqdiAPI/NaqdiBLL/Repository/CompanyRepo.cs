using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NaqdiBLL.Repository
{
    public class CompanyRepo : BestPaymentRepo<Company>
    {
        private NakqdiAppContext db;
        public CompanyRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }



        public IList<Company> getAll()
        {
            return db.Company.ToList();
            

        }
        public void add(Company newEntity)
        {
            db.Company.Add(newEntity);
            db.SaveChanges();

        }

        public void update(Company oldEntity)
        {
            
                db.Entry(oldEntity).State = EntityState.Modified;
                db.SaveChanges();
          
        }

        public IList<Company> FindByCondition(Expression<Func<Company, bool>> expression)
        {
            return db.Company.Where(expression).ToList();
        }

        public void Delet(Company Entity)
        {
            db.Company.Remove(Entity);
            db.SaveChanges();
        }


    }
}