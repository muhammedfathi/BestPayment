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
    public class PrivilageRepo: BestPaymentRepo<privilage>
    {

        private NakqdiAppContext db;

        public PrivilageRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(privilage newEntity)
        {
            db.privilage.Add(newEntity);
            db.SaveChanges();
        }

        public IList<privilage> FindByCondition(Expression<Func<privilage, bool>> expression)
        {
            return db.privilage.Where(expression).ToList();
        }

        public void Delet(privilage Entity)
        {
            db.privilage.Remove(Entity);
            db.SaveChanges();
        }

        public IList<privilage> getAll()
        {
            return db.privilage.ToList();
        }

        public void update(privilage oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}

