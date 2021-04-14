using Microsoft.EntityFrameworkCore;
using NaqdiBLL.IRepository;
using NaqdiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaqdiBLL.Repository
{
    public class GlobalConfigRepo : BestPaymentRepo<GlobalConfigration>
    {

        private NakqdiAppContext db;

        public GlobalConfigRepo(NakqdiAppContext _db)
        {
            this.db = _db;
        }


        public void add(GlobalConfigration newEntity)
        {
            db.GlobalConfigration.Add(newEntity);
            db.SaveChanges();
        }

        public void Delet(int id)
        {
            if (Find(id) != null)
            {
                db.GlobalConfigration.Remove(Find(id));
                db.SaveChanges();

            }

        }

        public GlobalConfigration Find(int Key)
        {
            return db.GlobalConfigration.Find(Key) ?? null;
        }

        public IList<GlobalConfigration> getAll()
        {
            return db.GlobalConfigration.ToList();
        }

        public void update(GlobalConfigration oldEntity)
        {
            db.Entry(oldEntity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}



