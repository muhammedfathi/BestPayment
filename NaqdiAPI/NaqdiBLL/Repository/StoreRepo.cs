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
    public class StoreRepo : BestPaymentRepo<Store>
    {

        private NakqdiAppContext db;

        public StoreRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(Store newEntity)
        {
            db.Store.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Store> FindByCondition(Expression<Func<Store, bool>> expression)
        {
            return db.Store.Where(expression).ToList();
        }

        public void Delet(Store Entity)
        {
            db.Store.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Store> getAll()
        {
            return db.Store.ToList();
        }

        public void update(Store oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}


