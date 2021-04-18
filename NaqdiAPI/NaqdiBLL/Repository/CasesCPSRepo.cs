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
    public class CasesCPSRepo : BestPaymentRepo<CasesCPS>
    {


        private NakqdiAppContext db;
        public CasesCPSRepo(NakqdiAppContext _db)
        {
            this.db = _db;

        }

        public void add(CasesCPS newEntity)
        {
            db.CasesCPS.Add(newEntity);
            db.SaveChanges();
        }

        public IList<CasesCPS> FindByCondition(Expression<Func<CasesCPS, bool>> expression)
        {
            return db.CasesCPS.Where(expression).ToList();
        }

        public void Delet(CasesCPS Entity)
        {
            db.CasesCPS.Remove(Entity);
            db.SaveChanges();
        }

        public IList<CasesCPS> getAll()
        {
           return db.CasesCPS.ToList();
        }

        public void update(CasesCPS oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
