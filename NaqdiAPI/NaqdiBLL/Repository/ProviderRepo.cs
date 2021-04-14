using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Provider.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Provider Find(int Key)
        {
            return db.Provider.Find(Key) ?? null;
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
