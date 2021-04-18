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
    public class ExecuteRepo : BestPaymentRepo<Excute>
    {
        private NakqdiAppContext db;

        public ExecuteRepo(NakqdiAppContext _db)
        {

            this.db = _db;

        }
        public void add(Excute newEntity)
        {
            db.Excute.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Excute> FindByCondition(Expression<Func<Excute, bool>> expression)
        {
            return db.Excute.Where(expression).ToList();
        }

        public void Delet(Excute Entity)
        {
            db.Excute.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Excute> getAll()
        {
            return db.Excute.ToList();
        }

        public void update(Excute oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}