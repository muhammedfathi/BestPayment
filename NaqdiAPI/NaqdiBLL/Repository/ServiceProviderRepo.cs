using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    public class ServiceProviderRepo : BestPaymentRepo<Service_Provider>
    {

        private NakqdiAppContext db;

        public ServiceProviderRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }

        public void add(Service_Provider newEntity)
        {
            db.Service_Providers.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Service_Providers.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Service_Provider Find(int Key)
        {
            return db.Service_Providers.Find(Key) ?? null;
        }

        public IList<Service_Provider> getAll()
        {
            return db.Service_Providers.ToList();
        }

        public void update(Service_Provider oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}


