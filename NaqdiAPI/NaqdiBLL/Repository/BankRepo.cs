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
    public class BankRepo : BestPaymentRepo<Banks>
    {

        private NakqdiAppContext db;
        public BankRepo(NakqdiAppContext _db )
        {
            this.db = _db;
        }
      

        public IList<Banks> getAll()
        {
           return db.Banks.ToList();
        
            
        }
        public void add(Banks newEntity)
        {
            db.Banks.Add(newEntity);
            db.SaveChanges();

        }

        public void update(Banks oldEntity)
        {
            
                db.Entry(oldEntity).State = EntityState.Modified;
                db.SaveChanges();
           
        }

        public void Delet(Banks Entity)
        {
            db.Banks.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Banks> FindByCondition(Expression<Func<Banks, bool>> expression)
        {
            return db.Banks.Where(expression).ToList();
        }

    }
}
