using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.ChargeSims.Remove(Find(id));
                db.SaveChanges();

            }
        }

        public ChargeSim Find(int Key)
        {
            return db.ChargeSims.Find(Key) ?? null;
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
