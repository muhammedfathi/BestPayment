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
    public class Provider_DepositeRepo : BestPaymentRepo<ProvidersDeposit>
    {
        private NakqdiAppContext db;

        public Provider_DepositeRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }



        public void add(ProvidersDeposit newEntity)
        {
            db.ProvidersDeposits.Add(newEntity);
            db.SaveChanges();
        }


        public IList<ProvidersDeposit> FindByCondition(Expression<Func<ProvidersDeposit, bool>> expression)
        {
            return db.ProvidersDeposits.Where(expression).ToList();
        }

        public void Delet(ProvidersDeposit Entity)
        {
            db.ProvidersDeposits.Remove(Entity);
            db.SaveChanges();
        }


        public IList<ProvidersDeposit> getAll()
        {
            return db.ProvidersDeposits.ToList();
        }

        public void update(ProvidersDeposit oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
