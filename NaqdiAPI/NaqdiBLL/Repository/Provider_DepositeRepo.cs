using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.ProvidersDeposits.Remove(Find(id));
                db.SaveChanges();

            }
        }

        public ProvidersDeposit Find(int Key)
        {
            return db.ProvidersDeposits.Find(Key) ?? null;
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
