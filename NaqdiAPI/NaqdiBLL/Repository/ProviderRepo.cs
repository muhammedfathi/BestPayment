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
    public class ProviderRepo: BestPaymentRepo<Provider>
    {
        private NakqdiAppContext db;

        public ProviderRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }


        public void add(Provider newEntity)
        {
            db.Provider.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Provider> FindByCondition(Expression<Func<Provider, bool>> expression)
        {
            return db.Provider.Where(expression).ToList();
        }

        public void Delet(Provider Entity)
        {
            db.Provider.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Provider> getAll()
        {
            return db.Provider.ToList();
        }

        public void update(Provider oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
