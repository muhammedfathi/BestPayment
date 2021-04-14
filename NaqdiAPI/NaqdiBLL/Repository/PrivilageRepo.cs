using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.privilage.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public privilage Find(int Key)
        {
            return db.privilage.Find(Key) ?? null;
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

