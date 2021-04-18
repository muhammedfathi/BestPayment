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

        public IList<Log> FindByCondition(Expression<Func<Log, bool>> expression)
        {
            return db.Log.Where(expression).ToList();
        }

        public void Delet(Log Entity)
        {
            db.Log.Remove(Entity);
            db.SaveChanges();
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

