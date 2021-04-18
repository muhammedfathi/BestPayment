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
    public class ServiceRepo : BestPaymentRepo<Service>
    {

        private NakqdiAppContext db;

        public ServiceRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(Service newEntity)
        {
            db.Service.Add(newEntity);
            db.SaveChanges();
        }

        public IList<Service> FindByCondition(Expression<Func<Service, bool>> expression)
        {
            return db.Service.Where(expression).ToList();
        }

        public void Delet(Service Entity)
        {
            db.Service.Remove(Entity);
            db.SaveChanges();
        }

        public IList<Service> getAll()
        {
            return db.Service.ToList();
        }

        public void update(Service oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}


