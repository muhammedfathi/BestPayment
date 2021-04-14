using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.Excute.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public Excute Find(int Key)
        {
            return db.Excute.Find(Key) ?? null;
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