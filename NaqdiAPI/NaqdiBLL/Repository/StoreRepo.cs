using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Store.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Store Find(int Key)
        {
            return db.Store.Find(Key) ?? null;
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


