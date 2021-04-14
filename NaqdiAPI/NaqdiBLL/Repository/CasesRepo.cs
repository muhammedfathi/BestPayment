using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
   public  class CasesRepo : BestPaymentRepo<cases>
    {
        private NakqdiAppContext db;
        public CasesRepo(NakqdiAppContext _db)
        {
            this.db = _db;

        }


        public IList<cases> getAll()
        {
            return db.cases.ToList();
        }
        public void add(cases newEntity)
        {
            db.cases.Add(newEntity);
            db.SaveChanges();

        }

        public void Delet(int id)
        {

            if (Find(id) != null)
            {
                db.cases.Remove(Find(id));
                db.SaveChanges();
            }


        }


        public void update(cases oldEntity)
        {
            
                db.Entry(oldEntity).State = EntityState.Modified;
                db.SaveChanges();
            
        }

        public cases Find(int Key)
        {
            return db.cases.Find(Key);
        }
    }
}
