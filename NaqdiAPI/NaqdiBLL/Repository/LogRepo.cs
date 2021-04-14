using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    public class LogRepo: BestPaymentRepo<Log>
    {

        private NakqdiAppContext db;

        public LogRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(Log newEntity)
        {
            db.Log.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Log.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Log Find(int Key)
        {
            return db.Log.Find(Key) ?? null;
        }

        public IList<Log> getAll()
        {
            return db.Log.ToList();
        }

        public void update(Log oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

