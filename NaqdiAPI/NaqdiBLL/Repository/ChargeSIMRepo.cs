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
    class ChargeSIMRepo: BestPaymentRepo<ChargeSim>
    {

        private NakqdiAppContext db;

        public ChargeSIMRepo(NakqdiAppContext _db)
        {

            this.db = _db;

        }

        public void add(ChargeSim newEntity)
        {
            db.ChargeSims.Add(newEntity);
            db.SaveChanges();
        }

        public IList<ChargeSim> FindByCondition(Expression<Func<ChargeSim, bool>> expression)
        {
            return db.ChargeSims.Where(expression).ToList();
        }

        public void Delet(ChargeSim Entity)
        {
            db.ChargeSims.Remove(Entity);
            db.SaveChanges();
        }

        public IList<ChargeSim> getAll()
        {
            return db.ChargeSims.ToList();
        }

        public void update(ChargeSim oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
