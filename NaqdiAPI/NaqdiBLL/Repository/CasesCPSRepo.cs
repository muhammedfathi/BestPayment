using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.CasesCPS.Remove(Find(id));
                db.SaveChanges();
            
            }
           
        }

        public CasesCPS Find(int Key)
        {
            return db.CasesCPS.Find(Key) ?? null;
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
