using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Service.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Service Find(int Key)
        {
            return db.Service.Find(Key) ?? null;
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


